using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhoWantsWhat.Models.ViewModels.ReportsViewModels
{
    public class ShoppingReportViewModel
    {
        public int ListTypeId { get; set; }
        public ListType ListType { get; set; }
        public int Year { get; set; }
        public List<GiftList> GiftLists { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPurchasedByUser { get; set; }
        public int ItemsPurchasedByOthers { get; set; }
        public int ItemsLeftToPurchase 
        { 
            get
            {
                return TotalItems - (ItemsPurchasedByUser + ItemsPurchasedByOthers);
            }
        }

        [DisplayFormat(DataFormatString = "{P}")]
        [Display(Name = "Percent Purchased by Me")]
        public double PercentPurchasedByUser 
        {
            get 
            {
                var percentage = (double)ItemsPurchasedByUser / (double)TotalItems * 100;
                percentage = Math.Round(percentage, 0);
                return percentage;
            }
        }

        [DisplayFormat(DataFormatString = "{P}")]
        [Display(Name = "Percent Purchased by Others")]
        public double PercentPurchasedByOthers 
        { 
            get
            {
                var percentage = (double)ItemsPurchasedByOthers / (double)TotalItems * 100;
                percentage = Math.Round(percentage, 0);
                return percentage;
            }
        }

        [Display(Name = "Percent Left to Purchase")]
        public double PercentLeftToPurchase
        {
            get
            {
                var percentage = 100 - (PercentPurchasedByUser + PercentPurchasedByOthers);
                return percentage;
            }
        }
        public List<double> Percentages 
        { 
            get 
            {
                var percentages = new List<double>
                { PercentPurchasedByUser, PercentPurchasedByOthers, PercentLeftToPurchase };
                return percentages;
            }
        }
    }
}
