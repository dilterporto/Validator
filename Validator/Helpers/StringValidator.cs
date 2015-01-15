using System.Text.RegularExpressions;
using Validator.Attributes;

namespace Validator.Helpers
{
    /// <summary>Validation helper that is used in <see cref="StringValidateAttribute"/></summary>
    public static class StringValidator
    {
        /// <summary>Checks whether <see cref="string"/> is valid</summary>
        /// <param name="str">String to validate</param>
        /// <param name="minLength">Minimum string length</param>
        /// <param name="maxLength">Maximum string length</param>
        /// <param name="canBeNull">Can string be null</param>
        /// <param name="canBeEmpty">Can string be empty</param>
        /// <param name="regEx">String regular expression</param>
        public static bool ValidateString(string str,
            int minLength = -1, int maxLength = -1, bool canBeNull = true, bool canBeEmpty = true, string regEx = null)
        {
            if (str == null)
                return canBeNull;

            if (str == string.Empty)
                return canBeEmpty;

            return
                (canBeEmpty || str != string.Empty) &&
                (minLength < 0 || str.Length >= minLength) &&
                (maxLength < 0 || str.Length <= maxLength) &&
                (regEx == null || Regex.IsMatch(str, regEx));
        }
    }
}
