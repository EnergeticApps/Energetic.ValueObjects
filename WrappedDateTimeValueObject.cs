using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Energetic.ValueObjects
{
    public abstract record WrappedDateTimeValueObject<TStrong> : ValueObject<TStrong, DateTime>
        where TStrong : IValueObject<TStrong, DateTime>
    {
        public WrappedDateTimeValueObject(int year, int month, int day) : base(new DateTime(year, month, day))
        {
        }

        public static TStrong Unknown => (TStrong)Activator.CreateInstance(typeof(TStrong), default(DateTime));
    }
}
