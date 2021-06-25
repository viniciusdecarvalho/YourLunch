using System;
namespace YourLunch.Domain
{
    public class Ingredient
    {
        internal static readonly Ingredient Zero =
            new Ingredient(0, name: string.Empty, price: decimal.Zero);

        public Ingredient(int code, string name, decimal price)
        {
            Code = code;
            Name = name;
            Price = price;
        }

        public int Code { get; }

        public string Name { get; }

        public decimal Price { get; }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Ingredient other)
            {
                return this.Code.Equals(other.Code);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }

        public override string ToString()
        {
            return $"({Code})[{Name}]";
        }
    }
}
