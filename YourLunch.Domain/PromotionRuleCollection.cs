using System;
using System.Collections;
using System.Collections.Generic;

namespace YourLunch.Domain
{
    public class PromotionRuleCollection : ICollection<PromotionRule>
    {
        private ICollection<PromotionRule> rules = new List<PromotionRule>();

        public int Count => this.rules.Count;

        public bool IsReadOnly => this.rules.IsReadOnly;

        public void Add(PromotionRule item)
        {
            this.rules.Add(item);
        }

        public void Clear()
        {
            this.rules.Clear();
        }

        public bool Contains(PromotionRule item)
        {
            return this.rules.Contains(item);
        }

        public void CopyTo(PromotionRule[] array, int arrayIndex)
        {
            this.rules.CopyTo(array, arrayIndex);
        }

        public IEnumerator<PromotionRule> GetEnumerator()
        {
            return this.rules.GetEnumerator();
        }

        public bool Remove(PromotionRule item)
        {
            return this.rules.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.rules.GetEnumerator();
        }
    }
}
