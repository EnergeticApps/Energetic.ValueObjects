using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Energetic.ValueObjects
{
    public abstract record WrappedDoubleValueObject<TStrong> : ValueObject<TStrong, double>
        where TStrong : IValueObject<TStrong, double>
    {
        public WrappedDoubleValueObject(double number) : base(number)
        {
        }

        public WrappedDoubleValueObject(string number) : this(double.Parse(number))
        {
        }
    }
}
