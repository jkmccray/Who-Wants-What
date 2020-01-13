using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WhoWantsWhat.Data;
using WhoWantsWhat.Models;
using WhoWantsWhat.Models.ViewModels.HomeViewModels;
using WhoWantsWhat.Models.ViewModels.ReportsViewModels;

namespace WhoWantsWhat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var month = DateTime.Now.Month;
            var nextMonth = DateTime.Now.Month + 1;
            var viewModel = new NotificationsViewModel()
            {
                UsersWithBirthdaysThisMonth = await _context.ApplicationUsers
                    .Include(u => u.GroupUsers)
                    .ThenInclude(gu => gu.Group)
                    .ThenInclude(g => g.GroupUsers)
                    .Where(u => u != user)
                    .Where(u => u.GroupUsers.Any(gu => gu.Group.GroupUsers.Any(gu => gu.User == user)))
                    .Where(u => u.Birthday.Month == DateTime.Now.Month)
                    .ToListAsync(),
                UsersWithBirthdaysNextMonth = await _context.ApplicationUsers
                    .Include(u => u.GroupUsers)
                    .ThenInclude(gu => gu.Group)
                    .ThenInclude(g => g.GroupUsers)
                    .Where(u => u != user)
                    .Where(u => u.GroupUsers.Any(gu => gu.Group.GroupUsers.Any(gu => gu.User == user)))
                    .Where(u => u.Birthday.Month == DateTime.Now.Month + 1)
                    .ToListAsync(),
                UpcomingGiftListsThisMonth = await _context.GiftLists
                    .Where(gl => gl.Creator == user && gl.DateNeeded.Year == DateTime.Now.Year && gl.DateNeeded.Month == DateTime.Now.Month)
                    .ToListAsync(),
                UpcomingGiftListsNextMonth = await _context.GiftLists
                    .Where(gl => gl.Creator == user && gl.DateNeeded.Year == DateTime.Now.Year && gl.DateNeeded.Month == DateTime.Now.Month + 1)
                    .ToListAsync()

            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
