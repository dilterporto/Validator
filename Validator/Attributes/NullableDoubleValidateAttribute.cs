using System;

namespace Validator.Attributes
{
    /// <summary>Specifies nullable <see cref="double"/> property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NullableDoubleValidateAttribute : DoubleValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public NullableDoubleValidateAttribute(string message)
            : base(message)
        {
        }

        /// <summary>Can be null</summary>
        public bool CanBeNull { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            if (value == null && !CanBeNull)
                return false;

            return base.IsValid(value);
        }
    }
}
