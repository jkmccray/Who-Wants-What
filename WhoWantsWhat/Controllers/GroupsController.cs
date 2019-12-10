using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhoWantsWhat.Data;
using WhoWantsWhat.Models;
using WhoWantsWhat.Models.ViewModels.GroupsViewModels;

namespace WhoWantsWhat.Controllers
{
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
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var groups = await _context.Groups
                .Include(g => g.GroupUsers)
                .ThenInclude(gu => gu.User)
                .Where(g => g.GroupUsers.Any(gu => gu.User == user && gu.Joined))
                .ToListAsync();
            return View(groups);
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
        //[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveGroupConfirmed(int GroupId)
        {
            var groupUser = await _context.GroupUsers.FirstOrDefaultAsync(gu => gu.GroupId == GroupId);
            _context.GroupUsers.Remove(groupUser);
            await _context.SaveChangesAsync();

            var inactiveGroup = await _context.Groups.FirstOrDefaultAsync(g => g.GroupId == GroupId);
            if (inactiveGroup.GroupUsers == null)
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
                    .Include(g => g.GroupUsers)
                    .FirstOrDefaultAsync(g => g.GroupId == GroupId),
                CurrentUser = await GetCurrentUserAsync()
            };

            return View(viewModel);
        }

        //[HttpPost, ActionName("AddPeopleToGroup")]
        //public async Task<IActionResult> SearchForPeople(AddToPeopleToGroupViewModel viewModel)
        //{

        //}

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}
