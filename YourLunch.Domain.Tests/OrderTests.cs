using System;
using Xunit;

namespace YourLunch.Domain.Tests
{
    public class OrderTests
    {
        [Fact]
        public void EmptyOrderShouldHaveZeroValues()
        {
            var order =
                new OrderBuilder()
                .Build();

            Assert.Equal(decimal.Zero, order.TotalPrice, 10);
            Assert.Equal(decimal.Zero, order.Discount, 10);
            Assert.Equal(decimal.Zero, order.FinalPrice, 10);
        }

        [Fact]
        public void OrderWithOneLunchShoudHaveTotalEqualThisLunch()
        {
            var order = new OrderBuilder()
                .AddXBurger()
                .Build();

            Assert.Equal(4.5M, order.TotalPrice, 10);
            Assert.Equal(decimal.Zero, order.Discount, 10);
            Assert.Equal(4.5M, order.FinalPrice, 10);
        }

        [Fact]
        public void EmptyOrderShouldHaveDiscountZeroWhenNotLunchsAndPromotionAdded()
        {
            var order = new OrderBuilder()
                .WithAllPromotions()
                .Build();

            Assert.Equal(decimal.Zero, order.TotalPrice, 10);
            Assert.Equal(decimal.Zero, order.Discount, 10);
            Assert.Equal(decimal.Zero, order.FinalPrice, 10);
        }

        [Fact]
        public void ShouldApplyDiscountWithOnlyPromotionLigth()
        {
            var order = 
                new OrderBuilder()
                    .WithAllPromotions()
                    .AddXBurger()
                    .AddLettuce()
                    .Build();            

            Assert.Equal(4.9M, order.TotalPrice, 10);
            Assert.Equal(0.49M, order.Discount, 10);
            Assert.Equal(4.41M, order.FinalPrice, 10);
        }

        [Fact]
        public void ShouldApplyLightDiscountWithAllPromotions()
        {
            Order order = new OrderBuilder()
                .WithAllPromotions()
                .AddXBurger()
                .AddLettuce()
                .Build();            

            Assert.Equal(4.9M, order.TotalPrice, 10);
            Assert.Equal(0.49M, order.Discount, 10);
            Assert.Equal(4.41M, order.FinalPrice, 10);
        }

        [Fact]
        public void ShouldApplyLightPromotionDiscountWhenXEggWithLuttuce()
        {
            Order order = new OrderBuilder()
                .WithAllPromotions()
                .AddXEgg()
                .AddLettuce()
                .Build();

            Assert.Equal(5.7M, order.TotalPrice, 10);
            Assert.Equal(0.57M, order.Discount, 10);
            Assert.Equal(5.13M, order.FinalPrice, 10);
        }

        [Theory]
        [InlineData(0, 4.50, 0.00, 4.50)]
        [InlineData(2, 10.5, 3.00, 7.50)]
        [InlineData(5, 19.5, 6.00, 13.50)]
        [InlineData(8, 28.5, 9.00, 19.50)]
        public void ShouldApplyLotOfBeefPromotionDiscountWhenMorePortionsOfBeefInOrder(
            int lotOfExtraBeef, decimal total, decimal discount, decimal final)
        {
            Order order = new OrderBuilder()
                .WithAllPromotions()
                .AddXBurger()
                .AddBeefBurger(lotOfExtraBeef)
                .Build();

            Assert.Equal(total, order.TotalPrice, 10);
            Assert.Equal(discount, order.Discount, 10);
            Assert.Equal(final, order.FinalPrice, 10);
        }

        [Theory]
        [InlineData(0, 5.30, 0.00, 5.30)]
        [InlineData(2, 8.30, 1.50, 6.80)]
        [InlineData(5, 12.80, 3.00, 9.80)]
        [InlineData(8, 17.30, 4.50, 12.80)]
        public void ShouldApplyLotOfCheesePromotionDiscountWhenMorePortionsOfCheeseInOrder(
            int lotOfExtraCheese, decimal total, decimal discount, decimal final)
        {
            Order order = new OrderBuilder()
                .WithAllPromotions()
                .AddXEgg()
                .AddCheese(lotOfExtraCheese)
                .Build();

            Assert.Equal(total, order.TotalPrice, 10);
            Assert.Equal(discount, order.Discount, 10);
            Assert.Equal(final, order.FinalPrice, 10);
        }
    }
}
