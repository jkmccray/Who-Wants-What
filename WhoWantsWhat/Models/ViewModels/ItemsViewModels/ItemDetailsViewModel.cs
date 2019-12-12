using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.ItemsViewModels
{
    public class ItemDetailsViewModel
    {
        public Item Item { get; set; }
        public int? WishListItemId { get; set; }
        public WishListItem WishListItem { get; set; }
        public int? GiftListItemId { get; set; }
        public GiftListItem GiftListItem { get; set; }
    }
}
