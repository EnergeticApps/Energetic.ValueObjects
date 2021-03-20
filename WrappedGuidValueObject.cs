using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Energetic.ValueObjects
{
    public abstract record WrappedGuidValueObject<TStrong> : ValueObject<TStrong, Guid>
        where TStrong : IValueObject<TStrong, Guid>
    {
        public WrappedGuidValueObject(Guid guid) : base(guid)
        {
        }

        public WrappedGuidValueObject(string guid) : this(new Guid(guid))
        {
        }

        public static TStrong FromNewGuid => (TStrong)Activator.CreateInstance(typeof(TStrong), Guid.NewGuid());

        public static TStrong Unknown => (TStrong)Activator.CreateInstance(typeof(TStrong), default(Guid));
    }
}
