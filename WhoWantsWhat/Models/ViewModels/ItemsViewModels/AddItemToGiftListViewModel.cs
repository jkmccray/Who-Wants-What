using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.ItemsViewModels
{
    public class AddItemToGiftListViewModel
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int GiftListId { get; set; }
        public int WishListId { get; set; }
    }
}
