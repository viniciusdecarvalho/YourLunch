using System;
using System.Linq;

namespace YourLunch.Domain
{
    public class PromotionLotOfCheeseRule : PromotionRule
    {
        public override bool CanApply(Order order)
        {
            var ingredients = order.Ingredients;

            return
                ingredients
                .Where(i => i.Name.Contains("Cheese", StringComparison.InvariantCultureIgnoreCase))
                .Count() > 2;
        }

        public override decimal Rule(Order order)
        {
            var ingredients = order.Ingredients;

            var query =
                from i in ingredients
                where i.Name.Contains("Cheese", StringComparison.InvariantCultureIgnoreCase)
                group i by new { i.Name, i.Price } into beef
                select new
                {
                    beef.Key.Name,
                    beef.Key.Price,
                    Count = beef.Count()
                };

            var first = query.FirstOrDefault();

            if (first.Count >= 3)
            {
                return (first.Count / 3) * first.Price;
            }

            return decimal.Zero;
        }
    }
}
