using CheckOutKata.Models;

namespace CheckoutKata.Interfaces
{
    public interface IPromotionManager
    {
        public decimal ApplyPromotions(Item item, int quantity);
    }
}
