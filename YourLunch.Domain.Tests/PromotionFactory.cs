using System;

namespace YourLunch.Domain.Tests
{
    internal class PromotionFactory
    {
        internal PromotionRule CreateLightRule()
        {
            return new PromotionLightRule();
        }

        internal Promotion CreateLight()
        {
            var rules = new PromotionRuleCollection
            {
                this.CreateLightRule()
            };

            var promotion = new Promotion(rules);

            return promotion;
        }

        internal PromotionRuleCollection CreateAllRules()
        {
            var rules = new PromotionRuleCollection
            {
                new PromotionLightRule(),
                new PromotionLotOfBeafRule(),
                new PromotionLotOfCheeseRule()
            };
            return rules;
        }

        internal Promotion CreateWithAllRules()
        {
            var promotion = new Promotion(this.CreateAllRules());

            return promotion;
        }
    }
}