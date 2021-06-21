using System;

namespace YourLunch.Domain.Tests
{
    public class IngredientFactory
    {
        /// <summary>
        /// <para>Bacon ($ 2,00)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateBacon()
        {
            return new Ingredient(name: "Bacon", 2.0M);
        }

        /// <summary>
        /// <para>Beef Burger ($ 3,00)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateBeefBurger()
        {
            return new Ingredient(name: "Beef Burger", 3.0M);
        }

        /// <summary>
        /// <para>Cheese ($ 1,50)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateCheese()
        {
            return new Ingredient(name: "Cheese", 1.5M);
        }

        /// <summary>
        /// <para>Lettuce ($ 0,40)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateLettuce()
        {
            return new Ingredient(name: "Lettuce", 0.4M);
        }

        /// <summary>
        /// <para>Egg ($ 0,80)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateEgg()
        {
            return new Ingredient(name: "Egg", 0.8M);
        }
    }
}