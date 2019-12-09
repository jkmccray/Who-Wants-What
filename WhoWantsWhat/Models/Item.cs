using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models
{
    public class Item
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public string Link { get; set; }
        [Required]
        public bool Purchased { get; set; }
        public double PurchasedAmount { get; set; }
        public ICollection<WishListItem> WishListItems { get; set; }
        public ICollection<GiftListItem> GiftListItems { get; set; }
    }
}
