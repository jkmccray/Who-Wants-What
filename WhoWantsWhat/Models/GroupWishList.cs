using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models
{
    public class GroupWishList
    {
        [Required]
        public int GroupWishListId { get; set; }
        [Required]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        [Required]
        public int WishListId { get; set; }
        public WishList WishList { get; set; }
    }
}
