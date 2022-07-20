using CheckOutKata.Models;

namespace CheckoutKata.Interfaces
{
    public interface IItemStore
    {
        public Item GetItem(string sku);
    }
}
