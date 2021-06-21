using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YourLunch.Domain
{
    public class Lunch: IEnumerable<Ingredient>
    {
        private readonly List<Ingredient> initialIngredients = new List<Ingredient>();
        private readonly List<Ingredient> othersIngredients = new List<Ingredient>();

        internal static readonly Lunch Empty = new Lunch();

        public Lunch(params Ingredient[] initialIngredients)
        {
            if (initialIngredients is null)
            {
                throw new ArgumentNullException(nameof(initialIngredients));
            }

            this.initialIngredients.AddRange(initialIngredients);
        }

        public void Add(params Ingredient[] ingredients)
        {
            if (ingredients is null)
            {
                throw new ArgumentNullException(nameof(ingredients));
            }

            this.othersIngredients.AddRange(ingredients);
        }

        private IEnumerable<Ingredient> All =>
            Enumerable.Concat(this.initialIngredients, this.othersIngredients);

        public IEnumerator<Ingredient> GetEnumerator()
        {
            return this.All.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.All.GetEnumerator();
        }

        public bool Contains(Ingredient ingredient) =>
            this.All.Contains(ingredient);

        public decimal TotalPrice =>
            this.DefaultIfEmpty(Ingredient.Zero).Sum(i => i.Price);
    }
}
