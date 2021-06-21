using System;
using System.Collections.Generic;
using System.Linq;

namespace YourLunch.Domain.Tests
{
    internal class OrderBuilder
    {
        private PromotionFactory promotionFactory;
        private IngredientFactory ingredientFactory;
        private LunchFactory lunchFactory;

        private PromotionRuleCollection promotions = new PromotionRuleCollection();
        private List<Lunch> lunchs = new List<Lunch>();

        public OrderBuilder()
        {
            this.promotionFactory = new PromotionFactory();
            this.ingredientFactory = new IngredientFactory();
            this.lunchFactory = new LunchFactory(ingredientFactory);
        }

        /// <summary>
        /// Add all promotions
        /// <para>Light, LotOfBeef, LotOfCheese</para>
        /// </summary>
        /// <returns>OrderBuilder</returns>
        internal OrderBuilder WithAllPromotions()
        {
            this.promotions = this.promotionFactory.CreateAllRules();

            return this;
        }

        /// <summary>
        /// Add XBurger ( $ 4,50 )
        /// </summary>
        /// <returns>OrderBuilder</returns>
        internal OrderBuilder AddXBurger()
        {
            var xBurger = this.lunchFactory.CreateXBurger();

            this.lunchs.Add(xBurger);

            return this;
        }

        /// <summary>
        /// Add Lettuce in last lunch ( $ 0,40 )
        /// </summary>
        /// <returns>OrderBuilder</returns>
        internal OrderBuilder AddLettuce()
        {
            var lettuce = this.ingredientFactory.CreateLettuce();
            Lunch lunch = GetLastLunch();
            lunch.Add(lettuce);
            return this;
        }

        /// <summary>
        /// Add Cheese in last lunch ( $ 1,50 )
        /// </summary>
        /// <returns>OrderBuilder</returns>
        internal OrderBuilder AddCheese(int count = 1)
        {
            Lunch lunch = GetLastLunch();

            for (int i = 0; i < count; i++)
            {
                var lettuce = this.ingredientFactory.CreateCheese();
                lunch.Add(lettuce);
            }

            return this;
        }

        /// <summary>
        /// Add Beef Burger in last lunch ( $ 3,00 )
        /// </summary>
        /// <returns>OrderBuilder</returns>
        internal OrderBuilder AddBeefBurger(int count = 1)
        {
            Lunch lunch = GetLastLunch();

            for (int i = 0; i < count; i++)
            {
                var beef = this.ingredientFactory.CreateBeefBurger();
                lunch.Add(beef);
            }

            return this;
        }

        private Lunch GetLastLunch()
        {
            var lunch = this.lunchs.LastOrDefault();

            if (lunch is null)
            {
                throw new InvalidOperationException("First include lunch.");
            }

            return lunch;
        }

        /// <summary>
        /// Add XEgg lunch( $ 5,30 )
        /// </summary>
        /// <returns>OrderBuilder</returns>
        internal OrderBuilder AddXEgg()
        {
            var xEgg = this.lunchFactory.CreateXEgg();

            this.lunchs.Add(xEgg);

            return this;
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <returns>Order</returns>
        internal Order Build()
        {
            var order = new Order();
            order.Add(this.lunchs.ToArray());
            order.Add(new Promotion(this.promotions));
            return order;
        }        
    }
}