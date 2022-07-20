using CheckoutKata.Interfaces;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public Checkout(Basket basket, IPromotionManager promotionManager)
        {
            _basket = basket;
            _promotionManager = promotionManager;
        }

        public decimal TotalCost()
        {
            decimal total = 0;

            foreach (var item in _basket.Items)
            {
                var itemCostWithPromotions = _promotionManager.ApplyPromotions(item.Key, item.Value);

                total += itemCostWithPromotions;
            }

            return total;
        }

        private readonly Basket _basket;
        private readonly IPromotionManager _promotionManager;
    }
}
