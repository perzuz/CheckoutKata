using CheckoutKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public Checkout(Basket basket)
        {
            _basket = basket;
        }

        public decimal TotalCost()
        {
            return _basket.Items.Sum(x => x.Price);
        }

        private readonly Basket _basket;
    }
}
