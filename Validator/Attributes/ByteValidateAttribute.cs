using System;

namespace Validator.Attributes
{
    /// <summary>Specifies <see cref="byte"/> property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ByteValidateAttribute : ValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public ByteValidateAttribute(string message)
            : base(message)
        {
            MinValue = byte.MinValue;
            MaxValue = byte.MaxValue;
        }

        /// <summary>Minimum value</summary>
        public byte MinValue { get; set; }

        /// <summary>Maximum value</summary>
        public byte MaxValue { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            var i = (byte)value;

            return MinValue <= i && i <= MaxValue;
        }
    }
}
