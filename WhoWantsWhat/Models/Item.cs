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
        [MaxLength(13)]
        public string Name { get; set; }
        [MaxLength(60)]
        public string Description { get; set; }
        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public string Link { get; set; }
        [Required]
        public bool Purchased { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name="Purchased Amount")]
        public double PurchasedAmount { get; set; }
        public string PurchaserId { get; set; }
        public ApplicationUser Purchaser { get; set; }
        public ICollection<WishListItem> WishListItems { get; set; }
        public ICollection<GiftListItem> GiftListItems { get; set; }
    }
}
