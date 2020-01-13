using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.HomeViewModels
{
    public class NotificationsViewModel
    {
        public List<ApplicationUser> UsersWithBirthdaysThisMonth { get; set; }
        public List<ApplicationUser> UsersWithBirthdaysNextMonth { get; set; }
        public List<GiftList> UpcomingGiftListsThisMonth { get; set; }
        public List<GiftList> UpcomingGiftListsNextMonth { get; set; }
    }
}
