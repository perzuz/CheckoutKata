using CheckoutKata.Interfaces;
using CheckOutKata.Models;

namespace CheckoutKata.Promotions
{
    public class ThreeForFourtyPromotion : IPromotion
    {
        public List<string> SKUs { get => _skus; set { _skus = value; } }

        public decimal ApplyPromotion(Item item, int quantity)
        {
            var remainder = quantity % RequiredPromotionQuantity;

            var remainderCost = remainder * item.Price;

            var numberOfOffers = quantity / RequiredPromotionQuantity;

            var offerCost = numberOfOffers * PromotionPrice;

            var total = remainderCost + offerCost;

            return total;
        }

        public bool IsPromotionApplicable(string sku)
        {
            return SKUs.Contains(sku);
        }

        private List<string> _skus = new List<string>() { "B" };
        private const int RequiredPromotionQuantity = 3;
        private const int PromotionPrice = 40;
    }
}
