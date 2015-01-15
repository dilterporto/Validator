using Validator.Helpers;

namespace Validator
{
    /// <summary>Object validation errors</summary>
    /// <typeparam name="T"></typeparam>
    public class ValidationErrors<T> : IValidationErrorsOfT<T> 
        where T : class
    {
        /// <summary>Constructor</summary>
        /// <param name="obj">Validated object</param>
        /// <param name="errors">Validation errors</param>
        public ValidationErrors(T obj, ValidationError[] errors)
        {
            Checker.ArgumentIsNull(obj, "obj");
            Checker.ArgumentIsNull(errors, "errors");
            Checker.Argument(errors.Length > 0, "errors.Length > 0");

            Object = obj;
            Errors = errors;
        }

        /// <summary>Validated object</summary>
        public T Object { get; private set; }

        /// <summary>Validation errors</summary>
        public ValidationError[] Errors { get; private set; }

        object IValidationErrors.Object
        {
            get { return Object; }
        }
    }
}
