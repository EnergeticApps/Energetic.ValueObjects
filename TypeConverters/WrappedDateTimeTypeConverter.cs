using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Energetic.ValueObjects.TypeConverters
{
    public class WrappedDateTimeTypeConverter<TStrong> : WrappedPrimitiveTypeConverterBase<TStrong, DateTime>
        where TStrong : ValueObject<TStrong, DateTime>
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var stringValue = value as string;
            if(!string.IsNullOrWhiteSpace(stringValue))
            {
                if (DateTime.TryParse(stringValue, out DateTime date))
                {
                    dynamic valueObject = Activator.CreateInstance(typeof(TStrong), date);
                    return valueObject;
                }
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
