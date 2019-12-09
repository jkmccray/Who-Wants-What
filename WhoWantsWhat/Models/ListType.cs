using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models
{
    public class ListType
    {
        [Required]
        public int ListTypeId { get; set; }
        [Required]
        public string Label { get; set; }
        public ICollection<GiftList> GiftLists { get; set; }
    }
}
