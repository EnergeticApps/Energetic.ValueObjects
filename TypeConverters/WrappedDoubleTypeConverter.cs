using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Energetic.ValueObjects.TypeConverters
{
    public class WrappedDoubleTypeConverter<TStrong> : WrappedPrimitiveTypeConverterBase<TStrong, double>
        where TStrong : ValueObject<TStrong, double>
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var stringValue = value as string;
            if(!string.IsNullOrWhiteSpace(stringValue))
            {
                if (double.TryParse(stringValue, out double number))
                {
                    dynamic valueObject = Activator.CreateInstance(typeof(TStrong), number);
                    return valueObject;
                }
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
