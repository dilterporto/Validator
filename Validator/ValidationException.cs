using System;
using Validator.Extensions;
using Validator.Helpers;

namespace Validator
{
    /// <summary>Validation exception</summary>
    public class ValidationException : Exception
    {
        /// <summary>Constructor</summary>
        /// <param name="errors">Validation errors</param>
        public ValidationException(IValidationErrors errors)
            : base(errors.ToExceptionMessage())
        {
            Checker.ArgumentIsNull(errors, "errors");

            Errors = errors;
        }

        /// <summary>Validation errors</summary>
        public IValidationErrors Errors { get; private set; }
    }
}
