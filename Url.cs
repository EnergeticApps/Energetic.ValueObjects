using Energetic.ValueObjects;
using Energetic.ValueObjects.JsonConverters;
using Energetic.ValueObjects.TypeConverters;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Energetic.Text;

namespace Energetic.ValueObjects
{
    [JsonConverter(typeof(WrappedStringJsonConverter<Url>))]
    [TypeConverter(typeof(WrappedStringTypeConverter<Url>))]
    public record Url : WrappedStringValueObject<Url>
    {
        public Url(string url) : base(url)
        {
            Validate();
        }

        protected override void Validate()
        {
            base.Validate();

            var validator = new UrlAttribute();
            if (!validator.IsValid(Value))
                throw new ArgumentException($"{Value} is not a valid URL.");
        }
    }
}