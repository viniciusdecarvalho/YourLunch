using System;
using System.Linq;
using System.Linq.Expressions;

namespace YourLunch.Domain
{
    public class Promotion
    {
        private readonly PromotionRuleCollection rules;

        public Promotion(
            PromotionRuleCollection rules
            )
        {
            this.rules = rules;
        }

        public decimal Calculate(Order order)
        {
            return this.rules.Sum(r => r.Apply(order));
        }
    }
}
