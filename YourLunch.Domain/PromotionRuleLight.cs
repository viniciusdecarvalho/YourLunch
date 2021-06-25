using System;
using System.Linq;

namespace YourLunch.Domain
{
    public class PromotionRuleLight : PromotionRule
    {
        public override bool CanApply(Order order)
        {
            var ingredients = order.Ingredients.Select(i => i.Value).ToList();

            var hasLettuce  = ingredients.Any(i => i.Name.Contains("Lettuce", StringComparison.InvariantCultureIgnoreCase));
            var hasBacon = ingredients.Any(i => i.Name.Contains("Bacon", StringComparison.InvariantCultureIgnoreCase));

            return hasLettuce && !hasBacon;
        }

        public override decimal Rule(Order order)
        {
            return order.TotalPrice * 0.1M;
        }
    }
}
