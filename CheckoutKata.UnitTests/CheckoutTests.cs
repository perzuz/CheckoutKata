using CheckOutKata.Models;

namespace CheckoutKata.UnitTests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void ThereIsAnItem_ItemIsAddedToBasket_ItemIsPresentIsBasket()
        {
            var item = new Item("A", 1);
            Basket basket = new Basket();

            basket.AddItem(item);

            Assert.AreEqual(1, basket.Items.Count);
        }
    }
}