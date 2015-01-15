namespace Validator
{
    /// <summary>Object validation errors</summary>
    public interface IValidationErrors
    {
        /// <summary>Validation errors</summary>
        ValidationError[] Errors { get; }

        /// <summary>Validated object</summary>
        object Object { get; }
    }
}
