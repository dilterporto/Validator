using System;
using Validator.Helpers;

namespace Validator.Attributes
{
    /// <summary>Specifies <see cref="string"/> property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class StringValidateAttribute : ValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public StringValidateAttribute(string message)
            : base(message)
        {
            MinLength = -1;
            MaxLength = -1;
            CanBeNull = true;
            CanBeEmpty = true;
            RegEx = null;
        }

        /// <summary>Minimum string length</summary>
        public int MinLength { get; set; }

        /// <summary>Maximum string length</summary>
        public int MaxLength { get; set; }

        /// <summary>Can string be null</summary>
        public bool CanBeNull { get; set; }

        /// <summary>Can string be empty</summary>
        public bool CanBeEmpty { get; set; }

        /// <summary>String regular expression</summary>
        public string RegEx { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            return StringValidator.ValidateString((string)value, MinLength, MaxLength, CanBeNull, CanBeEmpty, RegEx);
        }
    }
}
