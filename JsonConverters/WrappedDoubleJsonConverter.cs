namespace Energetic.ValueObjects.JsonConverters
{
    using System;
    using System.Text.Json;

    public class WrappedDoubleJsonConverter<TStrong> : WrappedPrimitiveJsonConverterBase<TStrong, double>
        where TStrong : ValueObject<TStrong, double>
    {
        public override TStrong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(reader.TryGetDouble(out var number))
            {
                dynamic valueObject = Activator.CreateInstance(typeof(TStrong), number);
                return valueObject;
            }
            
            throw new JsonException($"The JSON \"{reader.GetString()}\" cannot be parsed to type {typeof(double)}.");
        }
    }
}