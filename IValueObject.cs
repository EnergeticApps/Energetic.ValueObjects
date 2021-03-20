using System;

namespace Energetic.ValueObjects
{
    public interface IValueObject<TStrong, TPrimitive> : IComparable<TStrong>, IEquatable<TStrong>
        where TStrong : IValueObject<TStrong, TPrimitive>
        where TPrimitive : IComparable<TPrimitive>, IEquatable<TPrimitive>
    {
        TPrimitive Value { get; }
    }
}
