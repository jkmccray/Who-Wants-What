using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhoWantsWhat.Data;
using WhoWantsWhat.Models;
using WhoWantsWhat.Models.ViewModels.GroupsViewModels;

namespace WhoWantsWhat.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
     
        public GroupsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Groups
        public async Task<IActionResult> Index(string GroupSearchText)
        {
            var user = await GetCurrentUserAsync();
            // By default, display the groups the user is a member of
            if (GroupSearchText == null)
            {
                var viewModel = new MyGroupsAndSearchViewModel
                {
                    Groups = await _context.Groups
                    .Include(g => g.GroupUsers)
                    .ThenInclude(gu => gu.User)
                    .Where(g => g.GroupUsers.Any(gu => gu.User == user && gu.Joined))
                    .ToListAsync()
                };
                return View(viewModel);
            }
            // If the user has entered search text, display groups the user is not a member of (or has not been accepted into) based on the search text
            else
            {
                var viewModel = new MyGroupsAndSearchViewModel
                {
                    GroupSearchText = GroupSearchText,
                    Groups = await _context.Groups
                    .Include(g => g.GroupUsers)
                    .ThenInclude(gu => gu.User)
                    .Where(g => !g.GroupUsers.Any(gu => gu.User == user) || !g.GroupUsers.FirstOrDefault(gu => gu.User == user).Joined)
                    .Where(g => g.Name.Contains(GroupSearchText))
                    .ToListAsync()
                };
                return View(viewModel);
            }
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .Include(g => g.GroupUsers)
                .ThenInclude(gu => gu.User)
                .FirstOrDefaultAsync(m => m.GroupId == id);
            @group.GroupUsers = @group.GroupUsers.OrderBy(gu => gu.User.LastName).ToList();
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,Name")] Group @group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@group);
                await _context.SaveChangesAsync();

                var groupId = @group.GroupId;
                var user = await GetCurrentUserAsync();
                _context.Add(new GroupUser
                {
                    GroupId = groupId,
                    UserId = user.Id,
                    Joined = true
                });
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Leave group - Display view to confirm user wants to leave the group
        public async Task<IActionResult> LeaveGroup(int? GroupId)
        {
            if (GroupId == null)
            {
                return NotFound();
            }

            var groupUser = await _context.GroupUsers
                .Include(gu => gu.Group)
                .FirstOrDefaultAsync(gu => gu.GroupId == GroupId);
            if (groupUser == null)
            {
                return NotFound();
            }

            return View(groupUser);
        }

        // POST: Leave group confirmed
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveGroupConfirmed(int GroupId)
        {
            // Remove user from the group
            var user = await GetCurrentUserAsync();
            var groupUser = await _context.GroupUsers.FirstOrDefaultAsync(gu => gu.GroupId == GroupId && gu.User == user);
            _context.GroupUsers.Remove(groupUser);
            await _context.SaveChangesAsync();

            // Remove all entries in the GroupWishLists table, where user has shared wish lists with the group
            var groupWishLists = await _context.GroupWishLists
                .Include(gwl => gwl.WishList)
                .Where(gwl => gwl.WishList.UserId == user.Id && gwl.GroupId == GroupId)
                .ToListAsync();
            _context.RemoveRange(groupWishLists);
            await _context.SaveChangesAsync();

            // Check if group now has no users where Joined = true. If it does not have any, delete the group
            var inactiveGroup = await _context.Groups.Include(g => g.GroupUsers).FirstOrDefaultAsync(g => g.GroupId == GroupId);
            if (inactiveGroup.GroupUsers.Where(gu => gu.Joined).Count() == 0)
            {
                // Account for users that have requested to join but have not been added. Need to delete these entries in GroupUsers from the db
                var usersNotAddedToGroup = inactiveGroup.GroupUsers.Where(gu => !gu.Joined);
                _context.GroupUsers.RemoveRange(usersNotAddedToGroup);
                await _context.SaveChangesAsync();

                // Then remove the inactive group
                _context.Groups.Remove(inactiveGroup);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Display view to search for people to add to the group
        public async Task<IActionResult> AddPeopleToGroup(int GroupId)
        {
            var viewModel = new AddToPeopleToGroupViewModel
            {
                Group = await _context.Groups
                    .FirstOrDefaultAsync(g => g.GroupId == GroupId)
            };

            return View(viewModel);
        }

        // Search for users to add to the group and display search results
        public async Task<IActionResult> SearchForPeople(AddToPeopleToGroupViewModel viewModel)
        {
            var searchText = viewModel.SearchText;
            viewModel.Group = await _context.Groups
                    .Include(g => g.GroupUsers)
                    .FirstOrDefaultAsync(g => g.GroupId == viewModel.GroupId);
            viewModel.CurrentUser = await GetCurrentUserAsync();
            viewModel.Users = await _context.ApplicationUsers
                .Where(u => !u.GroupUsers.Any(gu => gu.GroupId == viewModel.GroupId))
                .Where(u => u.FirstName.Contains(searchText) || u.LastName.Contains(searchText))
                .ToListAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> AddUserToGroup(AddToPeopleToGroupViewModel viewModel)
        {
            var groupId = viewModel.GroupId;
            var userId = viewModel.UserId;
            var addedUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var existingGroupUser = await _context.GroupUsers.FirstOrDefaultAsync(gu => gu.GroupId == groupId && gu.UserId == userId && !gu.Joined);
            if (existingGroupUser == null)
            {
                var groupUser = new GroupUser
                {
                    GroupId = groupId,
                    UserId = userId,
                    Joined = true
                };
                _context.GroupUsers.Add(groupUser);
                await _context.SaveChangesAsync();

                var successMsg = TempData["SuccessMessage"] as string;
                TempData["SuccessMessage"] = $"{addedUser.FirstName} {addedUser.LastName} has been added to your group!";

                viewModel.Group = await _context.Groups.FirstOrDefaultAsync(g => g.GroupId == viewModel.GroupId);
                return RedirectToAction(nameof(SearchForPeople), new { 
                    GroupId = viewModel.GroupId,
                    SearchText = viewModel.SearchText,
                });
            }
            // accept user request to join group by changing Joined to true
            else
            {
                existingGroupUser.Joined = true;
                _context.GroupUsers.Update(existingGroupUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = groupId });
            }

        }

        public async Task<IActionResult> RequestToJoinGroup(RequestToJoinGroupViewModel viewModel)
        {
            var user = await GetCurrentUserAsync();
            var groupUser = new GroupUser
            {
                GroupId = viewModel.GroupId,
                UserId = user.Id,
                Joined = false
            };
            _context.GroupUsers.Add(groupUser);
            await _context.SaveChangesAsync();

            var groupSearchText = viewModel.GroupSearchText;
            return RedirectToAction(nameof(Index), new { GroupSearchText = groupSearchText });
        }

        public async Task<IActionResult> DeclineRequestToJoinGroup(RequestToJoinGroupViewModel viewModel)
        {
            var groupId = viewModel.GroupId;
            var userId = viewModel.UserId;
            var existingGroupUser = await _context.GroupUsers.FirstOrDefaultAsync(gu => gu.GroupId == groupId && gu.UserId == userId && !gu.Joined);
            _context.GroupUsers.Remove(existingGroupUser);
            await _context.SaveChangesAsync();
       
            return RedirectToAction(nameof(Details), new { id = groupId });
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}
