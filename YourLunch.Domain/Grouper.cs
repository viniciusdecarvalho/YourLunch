using System;
namespace YourLunch.Domain
{
    public class Grouper<T>
    {
        public Grouper(T value, int amount = 0)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
            this.SetAmount(amount);
        }

        public T Value { get; }

        public int Amount { get; private set; }

        public void Increment(int count = 1) =>
            this.SetAmount(this.Amount + count);

        public void Decrement(int count = 1) =>
            this.SetAmount(Math.Max(this.Amount - count, 0));

        public void SetAmount(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "amount must have positive value");
            }

            this.Amount = amount;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Grouper<T> other)
            {
                return this.Value.Equals(other.Value);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
