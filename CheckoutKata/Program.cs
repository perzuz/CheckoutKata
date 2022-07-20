using CheckoutKata;
using CheckoutKata.DataRepositories;
using CheckoutKata.Interfaces;
using CheckoutKata.Promotions;

var promotions = new List<Promotion>()
{
    new ThreeForFourtyPromotion(),
    new TwentyFivePercentOffEveryTwoPromotion()
};

var promotionManager = new PromotionManager(promotions);

IItemStore itemStore = new SampleItemStore();
var basket = new Basket();

basket.AddItem(itemStore.GetItem("A"), 1);
basket.AddItem(itemStore.GetItem("B"), 5);
basket.AddItem(itemStore.GetItem("Z"), 3);

var checkout = new Checkout(basket, promotionManager);

var total = checkout.TotalCost();

Console.WriteLine($"Total of basket is £{total}");
Console.Read();