using CheckOutKata.Models;

namespace CheckoutKata.Promotions
{
    public class TwentyFivePercentOffEveryTwoPromotion : Promotion
    {
        public override List<string> SKUs => _skus;

        public override decimal ApplyPromotion(Item item, int quantity)
        {
            var remainder = quantity % RequiredPromotionQuantity;

            var remainderCost = remainder * item.Price;

            var numberOfOffers = quantity / RequiredPromotionQuantity;

            var offerCost = numberOfOffers * (item.Price * RequiredPromotionQuantity * PercentageIncrease);

            var total = remainderCost + offerCost;

            return total;
        }

        private readonly List<string> _skus = new List<string>() { "D" };
        private const decimal PercentageIncrease = 0.75m;
        private const int RequiredPromotionQuantity = 2;
    }
}
