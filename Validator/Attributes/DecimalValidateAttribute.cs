using System;
using System.Globalization;

namespace Validator.Attributes
{
    /// <summary>Specifies <see cref="decimal"/> property that needs to be validated</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DecimalValidateAttribute : ValidateAttribute
    {
        /// <summary><see cref="NumberFormatInfo"/> to format values for <see cref="MinValueString"/> and <see cref="MaxValueString"/> properties</summary>
        public static readonly NumberFormatInfo NumberFormatInfo =
            new NumberFormatInfo { CurrencyDecimalSeparator = ".", NumberDecimalSeparator = "." };

        /// <summary>Constructor</summary>
        /// <param name="message">Validation message</param>
        public DecimalValidateAttribute(string message)
            : base(message)
        {
            MinValueString = decimal.MinValue.ToString(NumberFormatInfo);
            MaxValueString = decimal.MaxValue.ToString(NumberFormatInfo);
        }

        /// <summary>Minimum value</summary>
        public decimal MinValue
        {
            get { return decimal.Parse(MinValueString, NumberFormatInfo); }
        }

        /// <summary>Maximum value</summary>
        public decimal MaxValue
        {
            get { return decimal.Parse(MaxValueString, NumberFormatInfo); }
        }

        /// <summary>Minimum value string with '.' as decimal point</summary>
        /// <remarks>Use <see cref="NumberFormatInfo"/> property to format value</remarks>
        public string MinValueString { get; set; }

        /// <summary>Maximum value string with '.' as decimal point</summary>
        /// <remarks>Use <see cref="NumberFormatInfo"/> property to format value</remarks>
        public string MaxValueString { get; set; }

        /// <summary>Checks whether value is valid</summary>
        public override bool IsValid(object value)
        {
            var d = (decimal)value;

            return MinValue <= d && d <= MaxValue;
        }
    }

}
