using System;
using Xunit;

namespace YourLunch.Domain.Tests
{
    public class LunchTests
    {
        [Fact]
        public void EmptyLunchShouldBeHaveZeroPrice()
        {
            var lunch = new Lunch();

            Assert.Equal(0, lunch.TotalPrice, 10);
        }

        [Theory]
        [InlineData("Bacon", 1.9, 1.9)]
        public void ShouldHavePriceEqualSumOfIngredients(string name, decimal price, decimal total)
        {
            var bacon = new IngredientFactory()
                .CreateNew(name: name, price);

            var lunch = new Lunch(bacon);

            Assert.Equal(total, lunch.TotalPrice, 10);
        }
    }
}
