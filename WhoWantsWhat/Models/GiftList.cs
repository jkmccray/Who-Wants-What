using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name="Recipient Name")]
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public string ReceiverName { get; set; }
        [Required]
        [Display(Name="List Type")]
        public int ListTypeId { get; set; }
        public ListType ListType { get; set; }
        [Required]
        [Display(Name="Date Needed")]
        [DataType(DataType.Date)]
        public DateTime DateNeeded { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Budget { get; set; }
        public ICollection<GiftListItem> GiftListItems { get; set; }
        [NotMapped]
        [Display(Name="Amount Spent")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double AmountSpent { get; set; }
        [NotMapped]
        [Display(Name="Amount Left")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Difference { get; set; }
    }
}
