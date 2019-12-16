using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.WishListsViewModels
{
    public class ShareWishListViewModel
    {
        public int GroupId { get; set; }
        public int WishListId { get; set; }
        public WishList WishList { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<SelectListItem> GroupOptions
        {
            get
            {
                if (Groups == null) return null;

                List<SelectListItem> selectItems = Groups
                    .Select(g => new SelectListItem(g.Name, g.GroupId.ToString()))
                    .ToList();
                selectItems.Insert(0, new SelectListItem
                {
                    Text = "Choose group...",
                    Value = ""
                });

                return selectItems;
            }
        }
    }
}
