namespace Energetic.ValueObjects.JsonConverters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public abstract class WrappedPrimitiveJsonConverterBase<TStrong, TPrimitive> : JsonConverter<TStrong>
        where TStrong : ValueObject<TStrong, TPrimitive>
        where TPrimitive : IComparable<TPrimitive>, IEquatable<TPrimitive>
    {
        public override void Write(Utf8JsonWriter writer, TStrong value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.Value?.ToString());
        }
    }
}