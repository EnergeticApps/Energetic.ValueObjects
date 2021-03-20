using System;
using System.ComponentModel;

namespace Energetic.ValueObjects.TypeConverters
{
    public abstract class WrappedPrimitiveTypeConverterBase<TStrong, TPrimitive> : TypeConverter
        where TStrong : ValueObject<TStrong, TPrimitive>
        where TPrimitive : IComparable<TPrimitive>, IEquatable<TPrimitive>
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(TPrimitive) || sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
    }
}
