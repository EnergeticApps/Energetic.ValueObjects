using Energetic.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetValueObjectTypes(this IEnumerable<Type> markerTypes)
        {
            Type valueObjectOpenGenericType = typeof(IValueObject<,>);
            var assemblies = markerTypes.GetContainingAssemblies();
            return assemblies.GetConcreteTypes().Where(t => t.IsAssignableFromOpenGenericType(valueObjectOpenGenericType)).Distinct();
        }

        public static Type GetValueObjectBaseType(this Type valueObjectDerivedType)
        {
            var valueObjectBaseTypes = valueObjectDerivedType.GetClosedGenericBaseTypesMatchingOpenGenericType(ValueObject.ValueObjectOpenGenericType);

            if(valueObjectBaseTypes.Count() != 1)
            {
                throw new InvalidOperationException($"The type {valueObjectDerivedType.Name} is not derived from any type assignable to {ValueObject.ValueObjectOpenGenericType.Name}.");
            }

            return valueObjectBaseTypes.First();
        }
    }
}
