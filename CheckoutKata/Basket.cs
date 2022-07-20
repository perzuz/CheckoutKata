using CheckOutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (Items.Keys.Any(x => string.Equals(x.Sku, item.Sku, StringComparison.InvariantCultureIgnoreCase)))
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
