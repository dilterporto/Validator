using System;

namespace Validator.Helpers
{
    internal static class Checker
    {
        public static void ArgumentIsNull<TArgument>(TArgument arg, string argumentName)
            where TArgument : class
        {
            if (arg == null)
            {
                var message = string.Format("Argument '{0}' cannot be null.", argumentName);
                throw new ArgumentNullException(argumentName, message);
            }
        }

        public static void ArgumentIsEmpty(string arg, string argumentName)
        {
            if (string.IsNullOrEmpty(arg))
            {
                var message = string.Format("Argument '{0}' cannot be null or empty string.", argumentName);
                throw new ArgumentException(message, argumentName);
            }
        }

        public static void ArgumentIsWhitespace(string arg, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                var message = string.Format("Argument '{0}' cannot be null or empty string or contain only whitespaces.", argumentName);
                throw new ArgumentException(message, argumentName);
            }
        }

        public static void Argument(bool condition, string description)
        {
            if (!condition)
            {
                var message = string.Format("Argument does not meet the following '{0}' restriction.", description);
                throw new ArgumentException(message);
            }
        }
    }
}
