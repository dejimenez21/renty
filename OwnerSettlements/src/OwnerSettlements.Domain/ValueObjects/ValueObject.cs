namespace OwnerSettlements.Domain.ValueObjects
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? other)
        {
            if (other == null || other.GetType() != GetType())
            {
                return false;
            }
            var otherValueObject = (ValueObject)other;

            return GetEqualityComponents().SequenceEqual(otherValueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 23 + (obj?.GetHashCode() ?? 0);
                }
            });
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
    }
}
