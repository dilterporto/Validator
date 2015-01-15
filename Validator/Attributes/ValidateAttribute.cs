using System;
using Validator.Helpers;

namespace Validator.Attributes
{
    /// <summary>Parent class for all validation attributes</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public abstract class ValidateAttribute : Attribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        protected ValidateAttribute(string message)
        {
            Checker.ArgumentIsWhitespace(message, "message");

            Message = message;
        }

        /// <summary>Validation message</summary>
        public string Message { get; private set; }

        /// <summary>Validation key</summary>
        public string Key { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public abstract bool IsValid(object value);
    }
}
