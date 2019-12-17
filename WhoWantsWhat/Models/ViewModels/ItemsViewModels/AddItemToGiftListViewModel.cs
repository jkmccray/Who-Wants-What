using Microsoft.AspNetCore.Mvc.Rendering;
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
        public List<GiftList> GiftLists { get; set; } = new List<GiftList>();
        public List<SelectListItem> GiftListOptions
        {
            get
            {
                if (GiftLists == null) return null;

                List<SelectListItem> selectItems = GiftLists
                    .Select(gl => new SelectListItem(gl.Name, gl.GiftListId.ToString()))
                    .ToList();
                selectItems.Insert(0, new SelectListItem
                {
                    Text = "Select a gift list...",
                    Value = ""
                });

                return selectItems;
            }
        }
    }
}
