using CheckoutKata.Interfaces;
using CheckOutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.DataRepositories
{
    public class SampleItemStore : IItemStore
    {
        public Item GetItem(string sku)
        {
            if (!AvailableItems.Any(x => x.Sku == sku))
            {
                throw new KeyNotFoundException($"Item with SKU of {sku} not found");
            }

            return AvailableItems.Single(x => x.Sku == sku);
        }

        private List<Item> AvailableItems => new List<Item>
        {
            new Item("A", 10),
            new Item("B", 15),
            new Item("C", 40),
            new Item("D", 55)
        };
    }
}
