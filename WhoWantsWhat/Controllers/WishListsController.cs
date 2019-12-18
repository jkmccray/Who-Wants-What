using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhoWantsWhat.Data;
using WhoWantsWhat.Models;
using WhoWantsWhat.Models.ViewModels.WishListsViewModels;

namespace WhoWantsWhat.Controllers
{
    [Authorize]
    public class WishListsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishListsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: WishLists
        public async Task<IActionResult> Index(string UserId, int GroupId)
        {
            var user = await GetCurrentUserAsync();
            var wishLists = new List<WishList>();
            
            if (UserId == null)
            {
                wishLists = await _context.WishLists
                    .Include(w => w.WishListItems)
                    .ThenInclude(wi => wi.Item)
                    .Where(w => w.User == user)
                    .ToListAsync();
            }
            else
            {
                var sharedGroups = await _context.Groups
                    .Where(g => g.GroupUsers.Any(gu => gu.User == user && gu.Joined) && g.GroupUsers.Any(gu => gu.UserId == UserId && gu.Joined))
                    .ToListAsync();
                wishLists = await _context.WishLists
                    .Include(w => w.User)
                    .Include(w => w.WishListItems)
                    .ThenInclude(wi => wi.Item)
                    .Where(w => w.UserId == UserId)
                    .Where(w => w.GroupWishLists.Any(gwl => gwl.Group.GroupUsers.Any(gu => gu.User == user)))
                    .ToListAsync();
                if (wishLists.Count() == 0)
                {
                    TempData["ErrorMessage"] = "This user has not shared any wish lists with your groups";
                    return RedirectToAction(nameof(Details), "Groups", new { id = GroupId });
                }
            }
            return View(wishLists);
        }

        // GET: WishLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishList = await _context.WishLists
                .Include(w => w.GroupWishLists)
                .ThenInclude(gwl => gwl.Group)
                .Include(w => w.WishListItems)
                .ThenInclude(wli => wli.Item)
                .FirstOrDefaultAsync(m => m.WishListId == id);
            if (wishList == null)
            {
                return NotFound();
            }

            return View(wishList);
        }

        // GET: WishLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WishLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WishList wishList)
        {
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                wishList.UserId = user.Id;
                _context.Add(wishList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wishList);
        }

        // GET: WishLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishList = await _context.WishLists.FindAsync(id);
            if (wishList == null)
            {
                return NotFound();
            }
            return View(wishList);
        }

        // POST: WishLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WishListId,Name,UserId")] WishList wishList)
        {
            if (id != wishList.WishListId)
            {
                return NotFound();
            }

            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await GetCurrentUserAsync();
                    wishList.UserId = user.Id; 
                    _context.Update(wishList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishListExists(wishList.WishListId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = wishList.WishListId }) ;
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", wishList.UserId);
            return View(wishList);
        }

        // GET: WishLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishList = await _context.WishLists
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.WishListId == id);
            if (wishList == null)
            {
                return NotFound();
            }

            return View(wishList);
        }

        // POST: WishLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var wishListItems = await _context.WishListItems.Where(wli => wli.WishListId == id).ToListAsync();
            _context.RemoveRange(wishListItems);
            await _context.SaveChangesAsync();

            var wishList = await _context.WishLists.FindAsync(id);
            _context.WishLists.Remove(wishList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShareWishListView(int id)
        {
            var groupsAlreadySharedWith = await _context.Groups
                .Include(g => g.GroupWishLists)
                .Where(g => g.GroupWishLists.Any(gwl => gwl.WishListId == id))
                .ToListAsync();
            var user = await GetCurrentUserAsync();
            var wishList = await _context.WishLists
                    .Include(wl => wl.WishListItems)
                    .ThenInclude(wli => wli.Item)
                    .FirstOrDefaultAsync(wl => wl.WishListId == id);
            var viewModel = new ShareWishListViewModel
            {
                WishList = wishList,
                WishListId = wishList.WishListId,
                Groups = await _context.Groups
                    .Include(g => g.GroupUsers)
                    .Include(g => g.GroupWishLists)
                    .Where(g => g.GroupUsers.Any(gu => gu.User == user))
                    .Where(g => !g.GroupWishLists.Any(gwl => gwl.WishListId == id))
                    //.Except(groupsAlreadySharedWith)
                    .ToListAsync()
            };

            return View(viewModel);

        }
        public async Task<IActionResult> ShareWishList(ShareWishListViewModel viewModel)
        {
            var groupWishList = new GroupWishList
            {
                WishListId = viewModel.WishListId,
                GroupId = viewModel.GroupId
            };
            _context.Add(groupWishList);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
        private bool WishListExists(int id)
        {
            return _context.WishLists.Any(e => e.WishListId == id);
        }
    }
}
