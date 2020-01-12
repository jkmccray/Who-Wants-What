using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models
{
    public class WishListItem
    {
        [Required]
        public int WishListItemId { get; set; }
        [Required]
        public int WishListId { get; set; }
        public WishList WishList { get; set; }
        [Required]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [StringLength(28, ErrorMessage = "Please shorten notes to 100 characters")]
        [Display(Name ="Wish List Notes")]
        public string Notes { get; set; }
    }
}
