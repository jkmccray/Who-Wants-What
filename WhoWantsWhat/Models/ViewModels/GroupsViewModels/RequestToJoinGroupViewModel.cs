using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.GroupsViewModels
{
    public class RequestToJoinGroupViewModel
    {
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public string GroupSearchText { get; set; }
    }
}
