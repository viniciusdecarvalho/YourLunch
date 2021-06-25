using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YourLunch.Domain
{
    public class GrouperCollection<T> : IGrouperCollection<T>
    {
        private readonly ISet<Grouper<T>> groupers = new HashSet<Grouper<T>>();

        public IEnumerator<Grouper<T>> GetEnumerator()
        {
            return this.groupers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.groupers.GetEnumerator();
        }

        public void Add(T item)
        {
            Grouper<T> current = Find(item);

            current.Increment();

            this.groupers.Add(current);
        }

        internal void AddRange(params T[] values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            foreach (var val in values)
            {
                this.Add(val);
            }
        }

        private Grouper<T> Find(T item)
        {
            return this.groupers
                    .Where(l => l.Value.Equals(item))
                    .DefaultIfEmpty(new Grouper<T>(item))
                    .FirstOrDefault();
        }

        public void Remove(T item)
        {
            Grouper<T> current = Find(item);

            current.Decrement();

            if (current.Amount <= 0)
            {
                this.groupers.Remove(current);
            }
        }

        public bool Contains(T item)
        {
            Grouper<T> grouper = Find(item);

            return grouper.Amount > 0;
        }
    }
}
