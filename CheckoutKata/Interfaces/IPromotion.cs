using CheckOutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Interfaces
{
    public interface IPromotion
    {
        public List<string> SKUs { get; set; }

        public bool IsPromotionApplicable(string sku);

        public decimal ApplyPromotion(Item item, int quantity);
    }
}
