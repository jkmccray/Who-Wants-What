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
            else
            {
                var viewModel = new MyGroupsAndSearchViewModel
                {
                    GroupSearchText = GroupSearchText,
                    Groups = await _context.Groups
                    .Include(g => g.GroupUsers)
                    .ThenInclude(gu => gu.User)
                    .Where(g => !g.GroupUsers.Any(gu => gu.User == user))
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

        // GET: Leave group
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
            var user = await GetCurrentUserAsync();
            var groupUser = await _context.GroupUsers.FirstOrDefaultAsync(gu => gu.GroupId == GroupId && gu.User == user);
            _context.GroupUsers.Remove(groupUser);
            await _context.SaveChangesAsync();

            var inactiveGroup = await _context.Groups.Include(g => g.GroupUsers).FirstOrDefaultAsync(g => g.GroupId == GroupId);
            if (inactiveGroup.GroupUsers.Count == 0)
            {
                _context.Groups.Remove(inactiveGroup);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddPeopleToGroup(int GroupId)
        {
            var viewModel = new AddToPeopleToGroupViewModel
            {
                Group = await _context.Groups
                    .FirstOrDefaultAsync(g => g.GroupId == GroupId)
            };

            return View(viewModel);
        }

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

        public async Task<IActionResult> AddUserToGroup(IFormCollection form)
        {
            var groupId = int.Parse(Request.Form["GroupId"]);
            var userId = Request.Form["UserId"][0];
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
            }
            else
            {
                existingGroupUser.Joined = true;
                _context.GroupUsers.Update(existingGroupUser);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(Details), new { id = groupId });
        }

        public async Task<IActionResult> RequestToJoinGroup(IFormCollection form)
        {
            var user = await GetCurrentUserAsync();
            var groupUser = new GroupUser
            {
                GroupId = int.Parse(Request.Form["g.GroupId"]),
                UserId = user.Id,
                Joined = false
            };
            _context.GroupUsers.Add(groupUser);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}
