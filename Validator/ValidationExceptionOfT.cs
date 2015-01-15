using Validator.Helpers;

namespace Validator
{
    /// <summary>Validation exception</summary>
    /// <typeparam name="T">Validated object type</typeparam>
    public class ValidationExceptionOfT<T> : ValidationException
        where T : class
    {
        /// <summary>Constructor</summary>
        /// <param name="errors">Validation errors</param>
        public ValidationExceptionOfT(IValidationErrorsOfT<T> errors)
            : base(errors)
        {
            Checker.ArgumentIsNull(errors, "errors");

            Errors = errors;
        }

        /// <summary>Validation errors</summary>
        public new IValidationErrorsOfT<T> Errors { get; private set; }
    }
}
