using System;

namespace Validator.Attributes
{
    /// <summary>Specifies <see cref="int"/> property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IntValidateAttribute : ValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public IntValidateAttribute(string message)
            : base(message)
        {
            MinValue = int.MinValue;
            MaxValue = int.MaxValue;
        }

        /// <summary>Minimum value</summary>
        public int MinValue { get; set; }

        /// <summary>Maximum value</summary>
        public int MaxValue { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            var i = (int) value;

            return MinValue <= i && i <= MaxValue;
        }
    }
}
