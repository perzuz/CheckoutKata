namespace CheckOutKata.Models
{
    public class Item
    {
        public Item(string sku, decimal price)
        {
            Sku = sku;
            Price = price;
        }

        public string Sku { get; }
        public decimal Price { get; }
    }
}