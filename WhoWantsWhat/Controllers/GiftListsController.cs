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
using WhoWantsWhat.Models.ViewModels.GiftListsViewModels;

namespace WhoWantsWhat.Controllers
{
    [Authorize]
    public class GiftListsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GiftListsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: GiftLists
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var giftLists = await _context.GiftLists.Where(g => g.Creator == user).Include(g => g.ListType).Include(g => g.Receiver).ToListAsync();
            return View(giftLists);
        }

        // GET: GiftLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftList = await _context.GiftLists
                .Include(g => g.ListType)
                .Include(g => g.Receiver)
                .Include(g => g.GiftListItems)
                .ThenInclude(gli => gli.Item)
                .FirstOrDefaultAsync(m => m.GiftListId == id);
            if (giftList == null)
            {
                return NotFound();
            }

            return View(giftList);
        }

        // GET: GiftLists/Create
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            var viewModel = new CreateGiftListViewModel
            {
                Receivers = await _context.ApplicationUsers
                    .Include(u => u.GroupUsers)
                    .Where(u => u.Id != user.Id)
                    // filter to include users who share a group with the logged in user
                    .Where(u => u.GroupUsers
                        .Any(gu => gu.Group.GroupUsers
                            .Any(gu => gu.UserId == user.Id)))
                    .ToListAsync(),
                ListTypes = await _context.ListTypes.ToListAsync()
            };
            return View(viewModel);
        }

        // POST: GiftLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGiftListViewModel viewModel)
        {
            var user = await GetCurrentUserAsync();
            viewModel.ListTypes = await _context.ListTypes.ToListAsync();

            if (viewModel.GiftList.ReceiverId == null)
            {
                // if the user has not selected a receiver, get the possible receivers and listTypes from the db to use for the select lists
                viewModel.Receivers = await _context.ApplicationUsers
                    .Include(u => u.GroupUsers)
                    .Where(u => u.Id != user.Id)
                    // filter to include users who share a group with the logged in user
                    .Where(u => u.GroupUsers
                        .Any(gu => gu.Group.GroupUsers
                            .Any(gu => gu.UserId == user.Id)))
                    .ToListAsync();
                var successMsg = TempData["ErrorMessage"] as string;
                TempData["ErrorMessage"] = "Please select a receiver for this gift list";

                return View(viewModel);
            }

            ModelState.Remove("GiftList.CreatorId");
            if (ModelState.IsValid)
            {
                viewModel.GiftList.CreatorId = user.Id;

                // Check if the user selected "other" for the receiver
                if (viewModel.GiftList.ReceiverId == "0")
                {
                    // Have the user enter a name for the receiver
                    if (viewModel.GiftList.ReceiverName == null)
                    {
                       return View(viewModel);
                    }
                    // remove the receiver id of "0" so that the gift list can be entered into the db with a receiver id as null and a receiver name included
                    viewModel.GiftList.ReceiverId = null;
                }

                // add gift list to the db
                _context.Add(viewModel.GiftList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // if model state is not valid, get the possible receivers and listTypes from the db to use for the select lists
            viewModel.Receivers = await _context.ApplicationUsers
                .Include(u => u.GroupUsers)
                .Where(u => u.Id != user.Id)
                // filter to include users who share a group with the logged in user
                .Where(u => u.GroupUsers
                    .Any(gu => gu.Group.GroupUsers
                        .Any(gu => gu.UserId == user.Id)))
                .ToListAsync();
            return View(viewModel);
        }

        // GET: GiftLists/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = new EditGiftListViewModel();

            viewModel.GiftList = await _context.GiftLists.FindAsync(id);

            if (viewModel.GiftList == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();
            viewModel.Receivers = await _context.ApplicationUsers
                    .Include(u => u.GroupUsers)
                    .Where(u => u.Id != user.Id)
                    // filter to include users who share a group with the logged in user
                    .Where(u => u.GroupUsers
                        .Any(gu => gu.Group.GroupUsers
                            .Any(gu => gu.UserId == user.Id)))
                    .ToListAsync();
            viewModel.ListTypes = await _context.ListTypes.ToListAsync();
            
            return View(viewModel);
        }

        // POST: GiftLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGiftListViewModel viewModel)
        {
            var user = await GetCurrentUserAsync();
            viewModel.ListTypes = await _context.ListTypes.ToListAsync();

            if (viewModel.GiftList.ReceiverId == null || viewModel.GiftList.ReceiverId == "")
            {
                // if the user has not selected a receiver, get the possible receivers and listTypes from the db to use for the select lists
                viewModel.Receivers = await _context.ApplicationUsers
                    .Include(u => u.GroupUsers)
                    .Where(u => u.Id != user.Id)
                    // filter to include users who share a group with the logged in user
                    .Where(u => u.GroupUsers
                        .Any(gu => gu.Group.GroupUsers
                            .Any(gu => gu.UserId == user.Id)))
                    .ToListAsync();
                var successMsg = TempData["ErrorMessage"] as string;
                TempData["ErrorMessage"] = "Please select a receiver for this gift list";

                return View(viewModel);
            }

            ModelState.Remove("GiftList.CreatorId");
            if (ModelState.IsValid)
            {
                viewModel.GiftList.CreatorId = user.Id;

                // Check if the user selected "other" for the receiver
                if (viewModel.GiftList.ReceiverId == "0")
                {
                    // Have the user enter a name for the receiver
                    if (viewModel.GiftList.ReceiverName == null)
                    {
                        return View(viewModel);
                    }
                    // remove the receiver id of "0" so that the gift list can be entered into the db with a receiver id as null and a receiver name included
                    viewModel.GiftList.ReceiverId = null;
                }
                try
                {
                    // add gift list to the db
                    _context.Update(viewModel.GiftList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiftListExists(viewModel.GiftList.GiftListId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // if model state is not valid, get the possible receivers and listTypes from the db to use for the select lists
            viewModel.Receivers = await _context.ApplicationUsers
                .Include(u => u.GroupUsers)
                .Where(u => u.Id != user.Id)
                // filter to include users who share a group with the logged in user
                .Where(u => u.GroupUsers
                    .Any(gu => gu.Group.GroupUsers
                        .Any(gu => gu.UserId == user.Id)))
                .ToListAsync();
            return View(viewModel);
        }

        // GET: GiftLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftList = await _context.GiftLists
                .Include(g => g.ListType)
                .Include(g => g.Receiver)
                .Include(g => g.GiftListItems)
                .ThenInclude(gli => gli.Item)
                .FirstOrDefaultAsync(m => m.GiftListId == id);
            if (giftList == null)
            {
                return NotFound();
            }

            return View(giftList);
        }

        // POST: GiftLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giftListItems = await _context.GiftListItems.Where(gli => gli.GiftListId == id).ToListAsync();
            _context.RemoveRange(giftListItems);
            await _context.SaveChangesAsync();

            var giftList = await _context.GiftLists.FindAsync(id);
            _context.GiftLists.Remove(giftList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftListExists(int id)
        {
            return _context.GiftLists.Any(e => e.GiftListId == id);
        }
    }
}
