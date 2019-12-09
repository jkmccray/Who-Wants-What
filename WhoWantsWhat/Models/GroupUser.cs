using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models
{
    public class GroupUser
    {
        [Required]
        public int GroupUserId { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public bool Joined { get; set; }
        public Group Group { get; set; }
        public ApplicationUser User { get; set; }
    }
}
