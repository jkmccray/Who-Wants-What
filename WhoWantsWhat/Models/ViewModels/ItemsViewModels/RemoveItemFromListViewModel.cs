using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.ItemsViewModels
{
    public class RemoveItemFromListViewModel
    {
        public int ItemId { get; set; }
        public int WishListItemId { get; set; }
        public int GiftListItemId { get; set; }
    }
}
