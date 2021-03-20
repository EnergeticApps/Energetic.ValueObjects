using Energetic.Text;
using System;

namespace Energetic.ValueObjects
{
    public abstract record WrappedStringValueObject<TStrong> : ValueObject<TStrong, string>
        where TStrong : IValueObject<TStrong, string>
    {
        protected WrappedStringValueObject(string value) : base(value)
        {
            Validate();
        }

        public override string Value {
            get
            {
                return base.Value;
            }
            init
            {


                base.Value = value;
            }
        }
        

        protected virtual void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new StringArgumentNullOrWhiteSpaceException(nameof(Value));
        }
    }
}
