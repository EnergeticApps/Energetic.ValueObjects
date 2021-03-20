namespace Energetic.ValueObjects.JsonConverters
{
    using System;
    using System.Text.Json;

    public class WrappedGuidJsonConverter<TStrong> : WrappedPrimitiveJsonConverterBase<TStrong, Guid>
        where TStrong : ValueObject<TStrong, Guid>
    {
        public override TStrong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? json = reader.GetString();

            if (string.IsNullOrWhiteSpace(json))
            {
                throw new JsonException($"The {typeof(Utf8JsonReader)} does not contain a value.");
            }

            if (Guid.TryParse(json, out var guid))
            {
                dynamic valueObject = Activator.CreateInstance(typeof(TStrong), guid);
                return valueObject;
            }

            throw new JsonException($"The value \"{json}\" can't be parsed to a valid {typeof(DateTime)}.");
        }
    }
}