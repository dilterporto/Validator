using System;

namespace Validator.Attributes
{
    /// <summary>Specifies <see cref="short"/> property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ShortValidateAttribute : ValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public ShortValidateAttribute(string message)
            : base(message)
        {
            MinValue = short.MinValue;
            MaxValue = short.MaxValue;
        }

        /// <summary>Minimum value</summary>
        public short MinValue { get; set; }

        /// <summary>Maximum value</summary>
        public short MaxValue { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            var i = (short)value;

            return MinValue <= i && i <= MaxValue;
        }
    }
}
