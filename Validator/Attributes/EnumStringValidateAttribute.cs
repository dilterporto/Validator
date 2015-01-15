using System;
using System.Linq;
using Validator.Helpers;

namespace Validator.Attributes
{
    /// <summary>Specifies string enumeration property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class EnumStringValidateAttribute : ValidateAttribute
    {
        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        /// <param name="enumType"><see cref="Enum"/> type</param>
        public EnumStringValidateAttribute(string message, Type enumType)
            : base(message)
        {
            Checker.ArgumentIsNull(enumType, "enumType");
            Checker.Argument(enumType.IsEnum, "enumType.IsEnum");

            EnumType = enumType;

            CanBeNull = false;
        }

        /// <summary><see cref="Enum"/> type</summary>
        public Type EnumType { get; private set; }

        /// <summary>Can be null</summary>
        public bool CanBeNull { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            if (value == null)
                return CanBeNull;

            var str = (string)value;
            if (string.IsNullOrWhiteSpace(str))
                return false;

            return EnumType.GetEnumNames().Contains(str);
        }
    }
}
