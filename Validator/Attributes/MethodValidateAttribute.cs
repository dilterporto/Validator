using System;

namespace Validator.Attributes
{
    /// <summary>Specifies validation method that returns <see cref="ValidationError"/></summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MethodValidateAttribute : Attribute
    {
    }
}
