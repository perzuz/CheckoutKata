using CheckoutKata;
using CheckoutKata.DataRepositories;
using CheckoutKata.Interfaces;
using CheckoutKata.Promotions;
using CheckOutKata.Models;

var promotions = new List<Promotion>()
{
    new ThreeForFourtyPromotion(),
    new TwentyFivePercentOffEveryTwoPromotion()
};

var promotionManager = new PromotionManager(promotions);
IItemStore itemStore = new SampleItemStore();
var basket = new Basket();

//RunSampleMode(basket);
RunUserInputMode(basket);

var checkout = new Checkout(basket, promotionManager);

var total = checkout.TotalCost();

Console.WriteLine($"Total of basket is £{total}");
Console.Read();

void RunSampleMode(Basket basket)
{
    basket.AddItem(itemStore.GetItem("A"), 1);
    basket.AddItem(itemStore.GetItem("B"), 5);
    basket.AddItem(itemStore.GetItem("D"), 3);
}

void RunUserInputMode(Basket basket)
{
    Console.WriteLine("Welcome to the Checkout!" + Environment.NewLine);
    Console.WriteLine("Add your desired items to the basket below and type \"checkout\" when you are finished" + Environment.NewLine);

    while (Console.ReadLine() != "checkout")
    {
        Item itemToAdd = null;
        var quantity = 0;

        var itemFound = false;
        while (!itemFound)
        {
            Console.WriteLine("Enter an item SKU: ");
            string skuInput = Console.ReadLine();

            try
            {
                itemToAdd = itemStore.GetItem(skuInput);

                itemFound = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var quantityValid = false;
        while (!quantityValid)
        {
            Console.WriteLine("Enter desired quantity: ");
            string quantityInput = Console.ReadLine();

            try
            {
                quantity = Convert.ToInt32(quantityInput);
                quantityValid = true;
            }
            catch (Exception)
            {
                Console.WriteLine("please enter a valid quantity");
            }
        }

        basket.AddItem(itemToAdd, quantity);

        Console.WriteLine($"{quantity} X {itemToAdd.Sku} added to basket");
    }
}