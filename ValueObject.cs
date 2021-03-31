using System;

namespace Energetic.ValueObjects
{
    public abstract record ValueObject<TStrong, TPrimitive> : ValueObject, IValueObject<TStrong, TPrimitive>
        where TStrong : IValueObject<TStrong, TPrimitive>
        where TPrimitive : IComparable<TPrimitive>, IEquatable<TPrimitive>
    {
        private readonly TPrimitive _value = default!;

        protected ValueObject(TPrimitive value)
        {
            _value = value;
        }

        public virtual TPrimitive Value
        {
            get
            {
                return _value;
            }
            init
            {
                _value = value ?? throw new ArgumentNullException(nameof(Value));
            }
        }

        public int CompareTo(TStrong other) => Value.CompareTo(other.Value);

        public override int GetHashCode() => Value.GetHashCode();
        public override string ToString() => Value.ToString();

        public bool Equals(TStrong other)
        {
            return Value.Equals(other);
        }

        public static bool operator >=(ValueObject<TStrong, TPrimitive> a, ValueObject<TStrong, TPrimitive> b) => a.Value.CompareTo(b.Value) >= 0;
        public static bool operator <=(ValueObject<TStrong, TPrimitive> a, ValueObject<TStrong, TPrimitive> b) => !(a <= b);
        public static bool operator >(ValueObject<TStrong, TPrimitive> a, ValueObject<TStrong, TPrimitive> b) => a.Value.CompareTo(b.Value) > 0;
        public static bool operator <(ValueObject<TStrong, TPrimitive> a, ValueObject<TStrong, TPrimitive> b) => !(a < b);
    }

    public record ValueObject
    {
        public static Type ValueObjectOpenGenericType => typeof(IValueObject<,>);
    }
}