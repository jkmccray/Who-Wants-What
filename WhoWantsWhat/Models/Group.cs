using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models
{
    public class Group
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<GroupUser> GroupUsers{ get; set; }
    }
}
