using System.Collections.Generic;

namespace YourLunch.Domain
{
    public interface IGrouperCollection<T>: IEnumerable<Grouper<T>>
    {
        void Add(T item);

        bool Contains(T item);

        void Remove(T item);
    }
}