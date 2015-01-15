namespace Validator
{
    /// <summary>Object validation errors</summary>
    public interface IValidationErrorsOfT<out T> : IValidationErrors 
        where T : class
    {
        /// <summary>Validated object</summary>
        new T Object { get; }
    }
}
