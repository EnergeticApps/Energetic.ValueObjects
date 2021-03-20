using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Energetic.ValueObjects.JsonConverters
{
    public class WrappedStringJsonConverter<TStrong> : WrappedPrimitiveJsonConverterBase<TStrong, string>
        where TStrong : WrappedStringValueObject<TStrong>
    {
        public override TStrong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? json = reader.GetString();

            if (string.IsNullOrWhiteSpace(json))
            {
                throw new JsonException($"The {typeof(Utf8JsonReader)} does not contain a value.");
            }

            dynamic valueObject = Activator.CreateInstance(typeof(TStrong), json);
            return valueObject;
        }
    }
}
