using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.GroupsViewModels
{
    public class MyGroupsAndSearchViewModel
    {
        public List<Group> Groups { get; set; }
        public string GroupSearchText { get; set; }
    }
}
