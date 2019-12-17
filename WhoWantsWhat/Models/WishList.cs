using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models
{
    public class WishList
    {
        [Required]
        public int WishListId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<WishListItem> WishListItems { get; set; }
        public ICollection<GroupWishList> GroupWishLists { get; set; }

    }
}
