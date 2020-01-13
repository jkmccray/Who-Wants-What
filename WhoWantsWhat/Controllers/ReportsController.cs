using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhoWantsWhat.Data;
using WhoWantsWhat.Models;
using WhoWantsWhat.Models.ViewModels.ReportsViewModels;

namespace WhoWantsWhat.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReportsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var viewModel = new ListTypeViewModel
            {
                ListTypes = await _context.ListTypes.ToListAsync(),
                Years = await _context.GiftLists
                    .Where(gl => gl.Creator == user)
                    .OrderBy(gl => gl.DateNeeded)
                    .Select(gl => gl.DateNeeded.Year)
                    .Distinct()
                    .ToListAsync()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> SpendingReport(int ListTypeId, int Year)
        {
            var user = await GetCurrentUserAsync();

            var giftLists = await _context.GiftLists
                .Include(gl => gl.GiftListItems)
                .ThenInclude(gli => gli.Item)
                .Where(gl => gl.CreatorId == user.Id && gl.ListTypeId == ListTypeId && gl.DateNeeded.Year == Year)
                .ToListAsync();

            foreach(var gl in giftLists)
            {
                gl.AmountSpent = gl.GiftListItems.Select(gli => gli.Item.PurchasedAmount).Sum();
            }

            var viewModel = new BudgetReportViewModel
            {
                ListTypeId = ListTypeId,
                ListType = await _context.ListTypes.FindAsync(ListTypeId),
                Year = Year,
                GiftLists = giftLists,
                TotalAmountSpent = giftLists.Select(gl => gl.AmountSpent).Sum(),
                TotalBudget = giftLists.Select(gl => gl.Budget).Sum()
            };
            if (viewModel.ListTypeId == 0 || viewModel.Year == 0)
            {
                TempData["SpendingErrorMessage"] = "Please select a category and year.";
                return RedirectToAction(nameof(Index));
            }
            if (viewModel.GiftLists.Count() == 0)
            {
                TempData["SpendingErrorMessage"] = "No report for the selected category and year. Please try again.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
        public async Task<IActionResult> ShoppingReport(int ListTypeId, int Year)
        {
            var user = await GetCurrentUserAsync();

            var giftLists = await _context.GiftLists
                .Include(gl => gl.GiftListItems)
                .ThenInclude(gli => gli.Item)
                .Where(gl => gl.CreatorId == user.Id && gl.ListTypeId == ListTypeId && gl.DateNeeded.Year == Year)
                .ToListAsync();

            var viewModel = new ShoppingReportViewModel
            {
                ListTypeId = ListTypeId,
                ListType = await _context.ListTypes.FindAsync(ListTypeId),
                Year = Year,
                GiftLists = giftLists,
                TotalItems = giftLists.Select(gl => gl.GiftListItems.Count()).Sum(),
                ItemsPurchasedByUser = giftLists
                    .Select(gl => gl.GiftListItems.Where(gli => gli.Item.Purchaser == user && gli.Item.Purchased)
                    .Count()).Sum(),
                ItemsPurchasedByOthers = giftLists
                    .Select(gl => gl.GiftListItems.Where(gli => gli.Item.Purchaser != user && gli.Item.Purchased)
                    .Count()).Sum(),
            };
            if (viewModel.ListTypeId == 0 || viewModel.Year == 0)
            {
                TempData["ShoppingErrorMessage"] = "Please select a category and year.";
                return RedirectToAction(nameof(Index));
            }
            if (viewModel.TotalItems == 0)
            {
                TempData["ShoppingErrorMessage"] = "No report for the selected category and year. Please try again.";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }
    }
}