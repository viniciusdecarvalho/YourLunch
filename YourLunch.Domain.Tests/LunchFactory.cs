using System;

namespace YourLunch.Domain.Tests
{
    internal class LunchFactory
    {
        private readonly IngredientFactory ingredientes;

        public LunchFactory(IngredientFactory ingredientes)
        {
            this.ingredientes = ingredientes;
        }

        /// <summary>
        /// <para>Bacon($ 2,00) + Beef Burger($ 3,00) + Cheese($ 1,50)</para>
        /// <para>= $6,50</para>
        /// </summary>
        /// <returns>XBacon Lunch</returns>
        internal Lunch CreateXBacon()
        {
            return new Lunch(
                this.ingredientes.CreateBacon(),
                this.ingredientes.CreateBeefBurger(),
                this.ingredientes.CreateCheese()
            );
        }

        /// <summary>
        /// <para>Beef Burger($ 3,00) + Cheese($ 1,50)</para>
        /// <para>= $4,50</para>
        /// </summary>
        /// <returns>XBurger Lunch</returns>
        internal Lunch CreateXBurger()
        {
            return new Lunch(
                this.ingredientes.CreateBeefBurger(),
                this.ingredientes.CreateCheese()
            );
        }

        /// <summary>
        /// <para>Egg($ 0,80) + Beef Burger($ 3,00) + Cheese($ 1,50)</para>
        /// <para>= $5,30</para>
        /// </summary>
        /// <returns>XEgg Lunch</returns>
        internal Lunch CreateXEgg()
        {
            return new Lunch(
                this.ingredientes.CreateEgg(),
                this.ingredientes.CreateBeefBurger(),
                this.ingredientes.CreateCheese()
            );
        }
    }
}