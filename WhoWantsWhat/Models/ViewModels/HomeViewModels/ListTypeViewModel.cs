using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.ReportsViewModels
{
    public class ListTypeViewModel
    {
        public int ListTypeId { get; set; }
        public List<ListType> ListTypes { get; set; } = new List<ListType>();
        public List<SelectListItem> ListTypeOptions
        {
            get
            {
                if (ListTypes == null) return null;

                List<SelectListItem> selectItems = ListTypes
                    .Select(lt => new SelectListItem(lt.Label, lt.ListTypeId.ToString()))
                    .ToList();
                selectItems.Insert(0, new SelectListItem
                {
                    Text = "Choose category...",
                    Value = ""
                });

                return selectItems;
            }
        }
    }
}
