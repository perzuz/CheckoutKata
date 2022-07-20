using CheckOutKata.Models;

namespace CheckoutKata
{
    public abstract class Promotion
    {
        public abstract List<string> SKUs { get; }

        public abstract decimal ApplyPromotion(Item item, int quantity);

        public bool IsPromotionApplicable(string sku)
        {
            return SKUs.Contains(sku);
        }
    }
}
