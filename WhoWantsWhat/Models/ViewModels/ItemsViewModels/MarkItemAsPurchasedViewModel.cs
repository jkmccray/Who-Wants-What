using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.ItemsViewModels
{
    public class MarkItemAsPurchasedViewModel
    {
        public int ItemId { get; set; }
        public int GiftListId { get; set; }
        public int WishListId { get; set; }
    }
}
