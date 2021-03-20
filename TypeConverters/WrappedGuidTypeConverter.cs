using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Energetic.ValueObjects.TypeConverters
{
    public class WrappedGuidTypeConverter<TStrong> : WrappedPrimitiveTypeConverterBase<TStrong, Guid>
        where TStrong : ValueObject<TStrong, Guid>
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var stringValue = value as string;
            if(!string.IsNullOrWhiteSpace(stringValue))
            {
                if (Guid.TryParse(stringValue, out Guid guid))
                {
                    dynamic valueObject = Activator.CreateInstance(typeof(TStrong), guid);
                    return valueObject;
                }
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
