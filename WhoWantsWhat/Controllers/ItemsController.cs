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
using WhoWantsWhat.Models.ViewModels.ItemsViewModels;

namespace WhoWantsWhat.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ItemsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var wishListItems = await _context.WishListItems.Where(wli => wli.Item.CreatorId == user.Id).Include(wli => wli.WishList).ToListAsync();
            var items = await _context.Items
                .Where(i => i.Creator == user)
                //.Where(i => wishListItems.Any(wli => wli.ItemId == i.ItemId))
                .ToListAsync();
            return View(items);
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id, int? wishListItemId, int? giftListItemId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Creator)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            var viewModel = new ItemDetailsViewModel
            {
                Item = item
            };

            if (wishListItemId != null)
            {
                viewModel.WishListItemId = wishListItemId;
                viewModel.WishListItem = await _context.WishListItems.FindAsync(wishListItemId);
            }
            if (giftListItemId != null)
            {
                viewModel.GiftListItemId = giftListItemId;
                viewModel.GiftListItem = await _context.GiftListItems.FindAsync(giftListItemId);
            }
            return View(viewModel);
        }

        // GET: Items/Create
        public async Task<IActionResult> CreateItem(int? WishListId, int? GiftListId)
        {
            var viewModel = new CreateItemViewModel();

            if (WishListId != null)
            {
                viewModel.WishListId = WishListId;
                viewModel.WishList = await _context.WishLists.FindAsync(WishListId);
            }

            if (GiftListId != null)
            {
                viewModel.GiftListId = GiftListId;
                viewModel.GiftList = await _context.GiftLists.FindAsync(GiftListId);
            }

            return View(viewModel);
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateItemViewModel viewModel)
        {
            var item = viewModel.Item;

            ModelState.Remove("Item.CreatorId");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                item.CreatorId = user.Id;
                item.Purchased = false;
                _context.Items.Add(item);
                await _context.SaveChangesAsync();

                if (viewModel.WishListId != null)
                {
                    var wishListItem = new WishListItem
                    {
                        WishListId = (int)viewModel.WishListId,
                        ItemId = item.ItemId,
                        Notes = viewModel.WishListItem.Notes
                    };
                    _context.WishListItems.Add(wishListItem);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Details),"WishLists", new { id = viewModel.WishListId } );
                }
                if (viewModel.GiftListId != null)
                {
                    var giftListItem = new GiftListItem
                    {
                        GiftListId = (int)viewModel.GiftListId,
                        ItemId = item.ItemId,
                        Notes = viewModel.GiftListItem.Notes
                    };
                    _context.GiftListItems.Add(giftListItem);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Details), "GiftLists", new { id = viewModel.GiftListId });
                }

            }
            return View(viewModel);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int id, EditItemViewModel viewModel)
        {
            viewModel.Item = await _context.Items.FindAsync(viewModel.Item.ItemId);

            if (viewModel.WishListItemId > 0)
            { 
                viewModel.WishListItem = await _context.WishListItems
                    .Where(wi => wi.WishListItemId == viewModel.WishListItemId)
                    .FirstOrDefaultAsync();
            }
            if (viewModel.GiftListItemId > 0)
            {
                viewModel.GiftListItem = await _context.GiftListItems
                    .Where(wi => wi.GiftListItemId == viewModel.GiftListItemId)
                    .FirstOrDefaultAsync();
            }
            if (viewModel.Item == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditItemViewModel viewModel)
        {
            var item = viewModel.Item;

            ModelState.Remove("Item.CreatorId");
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await GetCurrentUserAsync();
                    item.CreatorId = user.Id;
                    _context.Update(item);
                    await _context.SaveChangesAsync();

                    if (viewModel.WishListItemId > 0)
                    {
                        var wishListItem = await _context.WishListItems.FindAsync(viewModel.WishListItemId);
                        wishListItem.Notes = viewModel.WishListItem.Notes;
                        _context.Update(wishListItem);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Details), new { id = item.ItemId, wishListItemId = wishListItem.WishListItemId });

                    }
                    if (viewModel.GiftListItemId > 0)
                    {
                        var wishListItem = await _context.GiftListItems.FindAsync(viewModel.GiftListItemId);
                        wishListItem.Notes = viewModel.WishListItem.Notes;
                        _context.Update(wishListItem);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.Creator)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wishListItems = await _context.WishListItems.Where(wli => wli.ItemId == id).ToListAsync();
            _context.WishListItems.RemoveRange(wishListItems);
            await _context.SaveChangesAsync();

            var giftListItems = await _context.GiftListItems.Where(gli => gli.ItemId == id).ToListAsync();
            _context.GiftListItems.RemoveRange(giftListItems);
            await _context.SaveChangesAsync();

            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveItemFromList(RemoveItemFromListViewModel viewModel)
        {
            if (viewModel.WishListItemId > 0)
            {
                var wishListItem = await _context.WishListItems.FindAsync(viewModel.WishListItemId);
                _context.WishListItems.Remove(wishListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "WishLists", new { id = wishListItem.WishListId });
            }
            if (viewModel.GiftListItemId > 0)
            {
                var giftListItem = await _context.GiftListItems.FindAsync(viewModel.GiftListItemId);
                _context.GiftListItems.Remove(giftListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "GiftLists", new { id = giftListItem.GiftListId });
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> AddItemToGiftList(AddItemToGiftListViewModel viewModel)
        {
            var user = await GetCurrentUserAsync();

            viewModel.GiftLists = await _context.GiftLists
                .Where(g => g.CreatorId == user.Id && g.ReceiverId == viewModel.UserId)
                .ToListAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> SaveWishListItemToGiftList(AddItemToGiftListViewModel viewModel)
        {
            var giftListItem = new GiftListItem
            {
                ItemId = viewModel.Item.ItemId,
                GiftListId = viewModel.GiftListId
            };
            _context.Add(giftListItem);
            await _context.SaveChangesAsync();
            var successMsg = TempData["SuccessMessage"] as string;
            TempData["SuccessMessage"] = "Added to your list";
            return RedirectToAction(nameof(Details), "WishLists", new { id = viewModel.WishListId });

        }

        public async Task<IActionResult> MarkItemAsPurchased(MarkItemAsPurchasedViewModel viewModel)
        {
            var user = await GetCurrentUserAsync();
            var item = await _context.Items.FindAsync(viewModel.ItemId);
            item.Purchased = true;
            item.PurchaserId = user.Id;
            _context.Update(item);
            await _context.SaveChangesAsync();

            if (viewModel.GiftListId > 0)
            {
                return RedirectToAction(nameof(Details), "GiftLists", new { id = viewModel.GiftListId });
            }
            if (viewModel.WishListId > 0)
            {
                return RedirectToAction(nameof(Details), "WishLists", new { id = viewModel.WishListId });
            }
            return RedirectToAction(nameof(Details), "Items", new { id = viewModel.ItemId });
        }

        public async Task<IActionResult> AddPurchaseAmount(Item Item)
        {
            var item = await _context.Items.FindAsync(Item.ItemId);
            item.PurchasedAmount = Item.PurchasedAmount;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "Items", new { id = item.ItemId });
        }

        public async Task<IActionResult> AddExistingItemToWishList(int ItemId)
        {
            var user = await GetCurrentUserAsync();
            var viewModel = new AddExistingItemToWishListViewModel
            {
                ItemId = ItemId,
                WishLists = await _context.WishLists
                    .Include(wl => wl.User)
                    .Where(wl => wl.User == user)
                    .Where(wl => !wl.WishListItems.Any(wli => wli.ItemId == ItemId))
                    .ToListAsync()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> SaveExistingItemToWishList(AddExistingItemToWishListViewModel viewModel)
        {
            var wishListItem = new WishListItem
            {
                ItemId = viewModel.ItemId,
                WishListId = viewModel.WishListId
            };
            _context.Add(wishListItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), "WishLists", new { id = viewModel.WishListId } );
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }

    }
}
