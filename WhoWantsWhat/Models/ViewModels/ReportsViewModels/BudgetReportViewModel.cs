using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.ReportsViewModels
{
    public class BudgetReportViewModel
    {
        public int ListTypeId { get; set; }
        public ListType ListType { get; set; }
        public int Year { get; set; }
        public List<GiftList> GiftLists { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total Amount Spent")]
        public double TotalAmountSpent { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total Amount Budgeted")]
        public double TotalBudget { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Difference
        {
            get
            {
                return TotalBudget - TotalAmountSpent;
            }
        }
    }
}
