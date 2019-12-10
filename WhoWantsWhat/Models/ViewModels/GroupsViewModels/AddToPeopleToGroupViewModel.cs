using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.GroupsViewModels
{
    public class AddToPeopleToGroupViewModel
    {
        public Group Group { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public string SearchText { get; set; }
        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
