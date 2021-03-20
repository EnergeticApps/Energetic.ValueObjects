using Energetic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace System.Reflection
{
    public static class PropertyInfoExtensions
    {
        public static bool HoldsAValueObject(this PropertyInfo property)
        {
            var propertyType = property.PropertyType;
            return propertyType.IsAssignableFromOpenGenericType(ValueObject.ValueObjectOpenGenericType);
        }
    }
}
