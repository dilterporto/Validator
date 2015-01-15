namespace Validator
{
    /// <summary>Validator that validates types with validation attributes</summary>
    public interface IValidator
    {
        /// <summary>Validates object and returns errors if validation failed</summary>
        /// <typeparam name="T">Object type to be validated</typeparam>
        /// <param name="obj">Object to be validated</param>
        IValidationErrorsOfT<T> Validate<T>(T obj)
            where T : class;

        /// <summary>Checks whether object is valid</summary>
        /// <typeparam name="T">Object type to be validated</typeparam>
        /// <param name="obj">Object to be validated</param>
        bool IsValid<T>(T obj)
            where T : class;

        /// <summary>Validates object and throw <see cref="ValidationExceptionOfT{T}"/> exception if validation failed</summary>
        /// <typeparam name="T">Object type to be validated</typeparam>
        /// <param name="obj">Object to be validated</param>
        void CheckIsValid<T>(T obj)
           where T : class;

    }
}
