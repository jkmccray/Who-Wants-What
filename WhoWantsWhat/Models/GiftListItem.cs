using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models
{
    public class GiftListItem
    {
        [Required]
        public int GiftListItemId { get; set; }
        [Required]
        public int GiftListId { get; set; }
        public GiftList GiftList { get; set; }
        [Required]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [StringLength(100, ErrorMessage = "Please shorten notes to 100 characters")]
        public string Notes { get; set; }
    }
}
