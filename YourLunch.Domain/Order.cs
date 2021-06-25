using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YourLunch.Domain
{
    public class Order
    {
        private readonly List<Lunch> lunchs = new List<Lunch>();
        private readonly List<Promotion> promotions = new List<Promotion>();

        #region Ctor

        public Order()
        {
        }

        #endregion

        public void Add(params Lunch[] lunch)
        {
            if (lunch is null)
            {
                throw new ArgumentNullException(nameof(lunch));
            }

            this.lunchs.AddRange(lunch);
        }

        public void Add(params Promotion[] promotion)
        {
            if (promotion is null)
            {
                throw new ArgumentNullException(nameof(promotion));
            }

            this.promotions.AddRange(promotion);
        }

        public IReadOnlyCollection<Lunch> Lunchs =>
            this.lunchs;

        public IReadOnlyCollection<Grouper<Ingredient>> Ingredients =>
            this.lunchs.SelectMany(l => l).ToList();

        public decimal Discount => 
            this.promotions.Sum(p => p.Calculate(this));
            
        public decimal TotalPrice =>
            this.lunchs.DefaultIfEmpty(Lunch.Empty).Sum(l => l.TotalPrice);

        public decimal FinalPrice => this.TotalPrice - this.Discount;
    }
}
