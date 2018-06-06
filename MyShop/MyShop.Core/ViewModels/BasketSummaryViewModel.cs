using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{
    public class BasketSummaryViewModel
    {
        public int BasketCount { get; set; }
        public decimal Baskettotal { get; set; }
        
        public BasketSummaryViewModel()
        {

        }

        public BasketSummaryViewModel(int basketCount,decimal basketTotal)
        {
            this.BasketCount = basketCount;
            this.Baskettotal = basketTotal;
        }
    }
}
