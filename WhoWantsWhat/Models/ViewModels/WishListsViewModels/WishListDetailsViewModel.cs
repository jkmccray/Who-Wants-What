using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.WishListsViewModels
{
    public class WishListDetailsViewModel
    {
        public WishList WishList { get; set; }
        public List<GiftListItem> GiftListItems { get; set; }
    }
}
