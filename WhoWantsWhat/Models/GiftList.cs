using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models
{
    public class GiftList
    {
        [Required]
        public int GiftListId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public string ReceiverName { get; set; }
        [Required]
        public int ListTypeId { get; set; }
        public ListType ListType { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateNeeded { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public int Budget { get; set; }
        public ICollection<GiftListItem> GiftListItems { get; set; }
    }
}
