using System;
using System.Linq;

namespace YourLunch.Domain
{
    public class PromotionRuleLotOfCheese : PromotionRule
    {
        public override bool CanApply(Order order)
        {
            return
                order.Ingredients
                .Where(i => i.Value.Name.Contains("Cheese", StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault()?.Amount >= 3;
        }

        public override decimal Rule(Order order)
        {

            var query =
                from i in order.Ingredients
                where i.Value.Name.Contains("Cheese", StringComparison.InvariantCultureIgnoreCase)
                where i.Amount >= 3
                select i;

            var first = query.FirstOrDefault();

            return ((first?.Amount / 3) * first?.Value.Price) ?? decimal.Zero;
        }
    }
}
