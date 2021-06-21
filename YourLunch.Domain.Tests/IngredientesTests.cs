using System;
using Xunit;

namespace YourLunch.Domain.Tests
{
    public class IngredientsTests
    {
        [Fact]
        public void ShouldBeCreateIngredient()
        {
            var ingredient = new Ingredient(name: "Bacon", price: 0.8M);

            Assert.Equal("Bacon", ingredient.Name);
            Assert.Equal(0.8M, ingredient.Price, 10);
        }

        //[Fact]
        //public void LunchShouldHaveIngredients2()
        //{
        //    var bacon = new Ingredient(name: "Bacon", price: 0.8M);
        //    var hamburguer = new Ingredient(name: "Beef burger", price: 3.3M);
        //    var cheese = new Ingredient(name: "Cheese", price: 1.1M);

        //    var lunch = new Lunch(new Ingredient[] { bacon, hamburguer, cheese });

        //    Assert.True(lunch.Contains(bacon));
        //    Assert.True(lunch.Contains(hamburguer));
        //    Assert.True(lunch.Contains(cheese));

        //    Assert.Equal(5.2M, lunch.TotalPrice, 10);
        //}

        //[Fact]
        //public void LunchShouldHaveIngredients3()
        //{

        //    var bacon = new Ingredient(name: "Bacon", price: 0.8M);
        //    var hamburguer = new Ingredient(name: "Beef burger", price: 3.3M);
        //    var cheese = new Ingredient(name: "Cheese", price: 1.1M);

        //    var lunch = new Lunch(new Ingredient[] { bacon, hamburguer, cheese });

        //    var promotion = new Promotion();

        //    var order = new Order(new Promotion[] { promotion });

        //    order.Add(lunch);            

        //    Assert.Equal(5.2M, order.TotalPrice, 10);

        //}
    }
}
