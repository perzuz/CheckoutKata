using CheckoutKata.Interfaces;
using CheckOutKata.Models;

namespace CheckoutKata
{
    public class PromotionManager : IPromotionManager
    {
        public PromotionManager(List<Promotion> promotions)
        {
            _promotions = promotions;
        }

        public decimal ApplyPromotions(Item item, int quantity)
        {
            if (!_promotions.Any(x => x.IsPromotionApplicable(item.Sku)))
            {
                return quantity * item.Price;
            }

            var costWithPromotion = _promotions.First(x => x.IsPromotionApplicable(item.Sku))
                .ApplyPromotion(item, quantity);

            return costWithPromotion;
        }

        private readonly List<Promotion> _promotions;
    }
}
