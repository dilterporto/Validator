using System;

namespace Validator.Attributes
{
    /// <summary>Specifies nullable <see cref="short"/> property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NullableShortValidateAttribute : ShortValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public NullableShortValidateAttribute(string message)
            : base(message)
        {
            CanBeNull = true;
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
