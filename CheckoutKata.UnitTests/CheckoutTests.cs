using CheckoutKata.Interfaces;
using CheckOutKata.Models;
using Moq;

namespace CheckoutKata.UnitTests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void ThereIsAnItem_ItemIsAddedToBasket_ItemIsPresentIsBasket()
        {
            var item = new Item("A", 10);
            Basket basket = new Basket();

            basket.AddItem(item);

            Assert.AreEqual(1, basket.Items.Count);
        }

        [TestMethod]
        public void ThereIsABasketWithItems_CheckoutIsFinsihed_TotalPriceIsCalculated()
        {
            var item1 = new Item("A", 10);
            var item2 = new Item("C", 40);
            Basket basket = new Basket();
            basket.AddItem(item1);
            basket.AddItem(item2);
            ICheckout checkout = new Checkout(basket);

            var actualTotal = checkout.TotalCost();

            Assert.AreEqual(50, actualTotal);
        }
    }
}