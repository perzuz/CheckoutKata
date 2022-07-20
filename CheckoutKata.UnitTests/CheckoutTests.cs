using CheckoutKata.Interfaces;
using CheckoutKata.Promotions;
using CheckOutKata.Models;

namespace CheckoutKata.UnitTests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void ThereIsAnItem_ItemIsAddedToBasket_ItemIsPresentIsBasket()
        {
            var item = new Item("A", 10);
            var basket = new Basket();

            basket.AddItem(item, 1);

            Assert.AreEqual(1, basket.Items.Count);
        }

        [TestMethod]
        public void ThereIsABasketWithItems_CheckoutIsFinished_TotalPriceIsCalculated()
        {
            var promotions = new List<Promotion>
            {
                new ThreeForFourtyPromotion()
            };

            IPromotionManager promotionManager = new PromotionManager(promotions);

            var item1 = new Item("A", 10);
            var item2 = new Item("C", 40);
            var basket = new Basket();
            basket.AddItem(item1, 1);
            basket.AddItem(item2, 1);
            ICheckout checkout = new Checkout(basket, promotionManager);

            var actualTotal = checkout.TotalCost();

            Assert.AreEqual(50m, actualTotal);
        }

        [TestMethod]
        public void CheckoutIsReady_AndThereIsAThreeForFourtyPromotion_TotalPriceIsCalculatedWithPromotions()
        {
            var promotions = new List<Promotion>
            {
                new ThreeForFourtyPromotion()
            };

            IPromotionManager promotionManager = new PromotionManager(promotions);

            var basket = new Basket();
            basket.AddItem(new Item("B", 15), 5);
            ICheckout checkout = new Checkout(basket, promotionManager);

            var actualTotal = checkout.TotalCost();

            Assert.AreEqual(70m, actualTotal);
        }

        [TestMethod]
        public void CheckoutIsReady_AndThereAreNoapplicablePromotions_TotalPriceIsCalculatedWithoutPromotions()
        {
            var promotions = new List<Promotion>
            {
                new ThreeForFourtyPromotion()
            };

            IPromotionManager promotionManager = new PromotionManager(promotions);

            var basket = new Basket();
            basket.AddItem(new Item("Z", 20), 5);
            ICheckout checkout = new Checkout(basket, promotionManager);

            var actualTotal = checkout.TotalCost();

            Assert.AreEqual(100m, actualTotal);
        }

        [TestMethod]
        public void CheckoutIsReady_AndThereIsATwentyFivePercentOffEveryTwoPromotion_TotalPriceIsCalculatedWithPromotions()
        {
            var promotions = new List<Promotion>
            {
                new TwentyFivePercentOffEveryTwoPromotion()
            };

            IPromotionManager promotionManager = new PromotionManager(promotions);

            var basket = new Basket();
            basket.AddItem(new Item("D", 55), 3);
            ICheckout checkout = new Checkout(basket, promotionManager);

            var actualTotal = checkout.TotalCost();

            Assert.AreEqual(137.50m, actualTotal);
        }
    }
}