using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YourLunch.Domain
{
    public class Lunch: IGrouperCollection<Ingredient>
    {
        private readonly GrouperCollection<Ingredient> ingredients = new GrouperCollection<Ingredient>();

        internal static readonly Lunch Empty = new Lunch();

        public Lunch(params Ingredient[] initialIngredients)
        {
            this.ingredients.AddRange(initialIngredients);
        }

        public decimal TotalPrice =>
            this.ingredients
                .DefaultIfEmpty(new Grouper<Ingredient>(Ingredient.Zero))
                .Sum(i => i.Amount * i.Value.Price);

        public int Count => throw new NotImplementedException();

        public void Add(Ingredient item)
        {
            this.ingredients.Add(item);
        }

        public bool Contains(Ingredient item)
        {
            return this.ingredients.Contains(item);
        }

        public void Remove(Ingredient item)
        {
            this.ingredients.Remove(item);
        }

        public IEnumerator<Grouper<Ingredient>> GetEnumerator()
        {
            return this.ingredients.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.ingredients.GetEnumerator();
        }
    }
}
