using System;
namespace YourLunch.Domain
{
    public class Ingredient
    {
        internal static readonly Ingredient Zero =
            new Ingredient(name: string.Empty, price: decimal.Zero);

        public Ingredient(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public decimal Price { get; }
    }
}
