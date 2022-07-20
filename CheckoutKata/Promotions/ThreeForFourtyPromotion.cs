using CheckoutKata.Interfaces;
using CheckOutKata.Models;

namespace CheckoutKata.Promotions
{
    public class ThreeForFourtyPromotion : Promotion
    {
        public override List<string> SKUs => _skus;

        public override decimal ApplyPromotion(Item item, int quantity)
        {
            var remainder = quantity % RequiredPromotionQuantity;

            var remainderCost = remainder * item.Price;

            var numberOfOffers = quantity / RequiredPromotionQuantity;

            var offerCost = numberOfOffers * PromotionPrice;

            var total = remainderCost + offerCost;

            return total;
        }


        private List<string> _skus = new List<string>() { "B" };
        private const int RequiredPromotionQuantity = 3;
        private const int PromotionPrice = 40;
    }
}
