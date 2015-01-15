using System;

namespace Validator.Attributes
{
    /// <summary>Specifies non-nullable property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NotNullValidateAttribute : ValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public NotNullValidateAttribute(string message)
            : base(message)
        {
        }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            return value != null;
        }
    }
}
