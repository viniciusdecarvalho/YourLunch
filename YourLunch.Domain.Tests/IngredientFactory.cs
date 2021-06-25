using System;

namespace YourLunch.Domain.Tests
{
    public class IngredientFactory
    {
        internal Ingredient CreateNew(string name, decimal price)
        {
            return new Ingredient(code: 0, name: name, price);
        }

        /// <summary>
        /// <para>Bacon ($ 2,00)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateBacon()
        {
            return new Ingredient(code: 1, name: "Bacon", 2.0M);
        }

        /// <summary>
        /// <para>Beef Burger ($ 3,00)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateBeefBurger()
        {
            return new Ingredient(code: 2, name: "Beef Burger", 3.0M);
        }        

        /// <summary>
        /// <para>Cheese ($ 1,50)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateCheese()
        {
            return new Ingredient(code: 3, name: "Cheese", 1.5M);
        }

        /// <summary>
        /// <para>Lettuce ($ 0,40)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateLettuce()
        {
            return new Ingredient(code: 4, name: "Lettuce", 0.4M);
        }

        /// <summary>
        /// <para>Egg ($ 0,80)</para>
        /// </summary>
        /// <returns>Ingredient</returns>
        internal Ingredient CreateEgg()
        {
            return new Ingredient(code: 5, name: "Egg", 0.8M);
        }
    }
}