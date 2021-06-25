using System;
using System.Collections.Generic;
using System.Linq;

namespace YourLunch.Domain
{
    public class PromotionRuleLotOfBeaf : PromotionRule
    {
        public override bool CanApply(Order order)
        {
            return
                QuantityOfBeef(order) > 2;
        }

        private int QuantityOfBeef(Order order)
        {
            var query =
                from i in order.Ingredients
                where i.Value.Name.Contains("Beef", StringComparison.InvariantCultureIgnoreCase)
                select i;

            return query.FirstOrDefault()?.Amount ?? 0;
        }

        public override decimal Rule(Order order)
        {
            var query =
                from i in order.Ingredients
                where i.Value.Name.Contains("Beef", StringComparison.InvariantCultureIgnoreCase)
                where i.Amount >= 3
                select i;

            var first = query.FirstOrDefault();

            return ((first?.Amount / 3) * first?.Value.Price) ?? decimal.Zero;
        }
    }
}
