namespace Energetic.ValueObjects.JsonConverters
{
    using System;
    using System.Text.Json;

    public class WrappedDateTimeJsonConverter<TStrong> : WrappedPrimitiveJsonConverterBase<TStrong, DateTime>
        where TStrong : ValueObject<TStrong, DateTime>
    {
        public override TStrong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? json = reader.GetString();

            if (string.IsNullOrWhiteSpace(json))
            {
                throw new JsonException($"The {typeof(Utf8JsonReader)} does not contain a value.");
            }

            if (DateTime.TryParse(json, out var date))
            {
                dynamic valueObject = Activator.CreateInstance(typeof(TStrong), date);
                return valueObject;
            }

            throw new JsonException($"The value \"{json}\" can't be parsed to a valid {typeof(DateTime)}.");
        }
    }
}