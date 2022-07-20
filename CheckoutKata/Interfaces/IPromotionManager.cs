using CheckOutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Interfaces
{
    public interface IPromotionManager
    {
        public decimal ApplyPromotions(Item item, int quantity);
    }
}
