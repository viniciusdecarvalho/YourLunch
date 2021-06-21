using System;
namespace YourLunch.Domain
{
    public abstract class PromotionRule
    {
        public virtual bool CanApply(Order order) => false;

        public virtual decimal Rule(Order order) => decimal.Zero;

        public decimal Apply(Order order)
        {
            if (CanApply(order))
            {
                return Rule(order);
            }

            return decimal.Zero;
        }
    }
}
