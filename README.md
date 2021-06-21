# YourLunch
Personalized snack sale

#### Description:

We are a startup in the food industry and we need an application to manage our business. Our specialty is the sale of snacks, so some snacks are menu options and others may contain custom ingredients.

Below, we present the list of available ingredients:

Ingredient | Price
----------- | ------------
Lettuce | $ 0.40
Bacon | $ 2,00
Beef Burger | $ 3,00
Egg | $ 0,80
Cheese | $ 1,50

Here are the menu options and their respective ingredients:

Lunch | Ingredients
----------- | ------------
X-Bacon | Bacon, Beef Burger and Cheese
X-Burger | Beef Burger and Chesse
X-Egg | Egg, Beef Burger and Cheese
X-Egg Bacon | Egg, Bacon, Beef Burger and Cheese

The value of each menu option is given by the sum of the ingredients that make up the snack

In addition to these options, customers can customize their snack and choose the ingredients they want. In this case, the price of the snack will also be calculated by adding up the ingredients.

There is an exception to the price calculation rule when the snack belongs to a promotion. Below, we present the list of promotions and their respective business rules:

Promotion | Business Rule
----------- | ------------
Light | If the snack has lettuce and no bacon, you get a 10% discount.
A lot of Meat | For every 3 portions of meat, the customer only pays 2. If the snack has 6 portions, the customer will pay 4. So on...
A lot of Cheese | For every 3 portions of cheese, the customer only pays 2. If the snack has 6 portions, the customer will pay 4. So on...

##### Inflation
Ingredient values ​​change frequently and we would not want this to influence automated testing.

The order form must have a timer counting how long the user is in the order screen. This time must be incremental every 1 second.