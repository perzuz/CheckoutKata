# CheckoutKata
CheckoutKata is a coding challenge that involves designing, developing and testing code to match the following requirements:

1. Given I have selected to add an item to the basket Then the item should be added to the basket
2. Given items have been added to the basket Then the total cost of the basket should be calculated
3. Given I have added a multiple of 3 lots of item ‘B’ to the basket Then a promotion of ‘3 for 40’ should be applied to every multiple of 3 (see: Grid 1).
4. Given I have added a multiple of 2 lots of item ‘D’ to the basket Then a promotion of ‘25% off’ should be applied to every multiple of 2 (see: Grid 1)

![image](https://user-images.githubusercontent.com/19329568/180172511-3461d9bc-939f-4c3b-8e7f-1a1df56ff6c4.png)

## Assumptions
- An item can only have one promotion assigned to it at a time 

## Testing
For this Kata I utilised Test Driven Development to define the behaviour of the code before writing the implementation. Having a suite of unit tests that defined the correct behaviour of the application at any point meant that i could implement new changes and refactor code with full confidence that the application was still working as intended.

I also wrote a few characterisation tests during development where i would throw some test values into the test items to see how the code handles them. These were useful for getting an insight into behaviour and catching possible bugs.

## Design Notes
- IItemStore interface: I have used IItemStore as an interface for client code to retreive item data from. For the purposes of this kata I created a SampleItemStore class that implements IItemStore, this class stores a hard coded private list of Items that can be retrieved using the public GetItem Method. The idea behind this design choice was that is allows the creation of other data repository classes that may retrieve data from a different source (e.g a database, Json/XML file) without the need for modification of existing client code (so long as the classes implement the IItemStore interface). One improvement could be to add CRUD methods to the interface so that clients could add, remove, update Items as well as retrieve them.

- Promotions: The promotion manager owns a list of Promotions. Promotion was originally an interface called IPromotion with the idea being that the behaviour of the code could be extended to include new promotions with their own logic. When i was developing the second promotion (25% off for every 2) I noticed that the IsPromotionApplicable method was the same across both promotions so i decided to get rid of the interface and create an abstract class so sub-classes could all utilise the shared behaviour of checking wether or not a promotion was applicable for a given item. 
