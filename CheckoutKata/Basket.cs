using CheckOutKata.Models;

namespace CheckoutKata
{
    public class Basket
    {
        public Basket()
        {
            Items = new Dictionary<Item, int>();
        }

        public Dictionary<Item, int> Items { get; private set; }

        public void AddItem(Item item, int quantity)
        {
            if (item == null || quantity < 0) return;

            if (Items.Keys.Contains(item))
            {
                Items[item] += quantity;
            }
            else
            {
                Items.Add(item, quantity);
            }
        }
    }
}
