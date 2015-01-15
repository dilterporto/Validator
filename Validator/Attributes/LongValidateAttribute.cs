using System;

namespace Validator.Attributes
{
    /// <summary>Specifies <see cref="long"/> property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LongValidateAttribute : ValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public LongValidateAttribute(string message)
            : base(message)
        {
            MinValue = long.MinValue;
            MaxValue = long.MaxValue;
        }

        /// <summary>Minimum value</summary>
        public long MinValue { get; set; }

        /// <summary>Maximum value</summary>
        public long MaxValue { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            var i = (long)value;

            return MinValue <= i && i <= MaxValue;
        }
    }
}
