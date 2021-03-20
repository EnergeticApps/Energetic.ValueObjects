using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Energetic.ValueObjects.TypeConverters
{
    public class WrappedStringTypeConverter<TStrong> : WrappedPrimitiveTypeConverterBase<TStrong, string>
        where TStrong : ValueObject<TStrong, string>
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var stringValue = value as string;
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                dynamic valueObject = Activator.CreateInstance(typeof(TStrong), stringValue);
                return valueObject;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
