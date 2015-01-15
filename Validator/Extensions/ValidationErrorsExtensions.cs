using System.Text;
using Validator.Helpers;

namespace Validator.Extensions
{
    internal static class ValidationErrorsExtensions
    {
        public static string ToExceptionMessage(this IValidationErrors validateErrors)
        {
            Checker.ArgumentIsNull(validateErrors, "validateErrors");

            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Invalid object: ");
            stringBuilder.AppendLine(validateErrors.Object.ToString());
            stringBuilder.AppendLine("Errors: ");

            foreach (var error in validateErrors.Errors)
            {
                stringBuilder.Append("Key: ");
                stringBuilder.Append(error.Key);
                stringBuilder.Append(" Message: ");
                stringBuilder.AppendLine(error.Message);
            }

            return stringBuilder.ToString();
        }
    }
}
