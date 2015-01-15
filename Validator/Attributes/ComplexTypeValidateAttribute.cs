using System;

namespace Validator.Attributes
{
    /// <summary>Specifies complex type property that needs to be validated</summary>
    /// <remarks>This attribute shows that property type has properties with validation attributes</remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ComplexTypeValidateAttribute : Attribute
    {
    }
}
