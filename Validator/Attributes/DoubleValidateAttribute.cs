using System;

namespace Validator.Attributes
{
    /// <summary>Specifies <see cref="double"/> property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DoubleValidateAttribute : ValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public DoubleValidateAttribute(string message)
            : base(message)
        {
            MinValue = double.MinValue;
            MaxValue = double.MaxValue;
        }

        /// <summary>Minimum value</summary>
        public double MinValue { get; set; }

        /// <summary>Maximum value</summary>
        public double MaxValue { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            var i = (double)value;

            return MinValue <= i && i <= MaxValue;
        }
    }
}
