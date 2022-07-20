using CheckoutKata.Interfaces;
using CheckOutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class PromotionManager : IPromotionManager
    {
        public PromotionManager(List<IPromotion> promotions)
        {
            _promotions = promotions;
        }

        public decimal ApplyPromotions(KeyValuePair<Item, int> item)
        {
            if (!_promotions.Any(x => x.IsPromotionApplicable(item.Key.Sku)))
            {
                return item.Value * item.Key.Price;
            }

            var costWithPromotion = _promotions.First(x => x.IsPromotionApplicable(item.Key.Sku))
                .ApplyPromotion(item.Key, item.Value);

            return costWithPromotion;
        }

        private readonly List<IPromotion> _promotions;
    }
}
