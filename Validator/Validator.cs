using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validator.Attributes;
using Validator.Helpers;
using Validator.Extensions;

namespace Validator
{
    /// <summary>Validator that validates types with validation attributes</summary>
    public class Validator : IValidator
    {
        /// <summary>Validates object and returns errors if validation failed</summary>
        /// <typeparam name="T">Object type to be validated</typeparam>
        /// <param name="obj">Object to be validated</param>
        public IValidationErrorsOfT<T> Validate<T>(T obj)
             where T : class
        {
            Checker.ArgumentIsNull(obj, "obj");

            if (obj.GetType() != typeof (T))
                return null;

            var validationErrors = 
                GetValidationErrors(obj)
                    .ToArray();

            return validationErrors.Length > 0 ? new ValidationErrors<T>(obj, validationErrors) : null;
        }

        /// <summary>Checks whether object is valid</summary>
        /// <typeparam name="T">Object type to be validated</typeparam>
        /// <param name="obj">Object to be validated</param>
        public bool IsValid<T>(T obj)
            where T : class
        {
            Checker.ArgumentIsNull(obj, "obj");

            var errors = Validate(obj);

            return errors == null;
        }

        /// <summary>Validates object and throw <see cref="ValidationExceptionOfT{T}"/> exception if validation failed</summary>
        /// <typeparam name="T">Object type to be validated</typeparam>
        /// <param name="obj">Object to be validated</param>
        public void CheckIsValid<T>(T obj)
            where T : class
        {
            Checker.ArgumentIsNull(obj, "obj");

            var errors = Validate(obj);

            if (errors != null)
                throw new ValidationExceptionOfT<T>(errors);
        }

        private IEnumerable<ValidationError> GetValidationErrors(object obj)
        {
            Checker.ArgumentIsNull(obj, "obj");

            const BindingFlags BINDING_ATTR =
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static;

            // Properties
            var propertiesValidationErrors = GetPropertiesValidationErrors(obj, BINDING_ATTR);

            // Methods
            var methodsValidationErrors =
                from method in obj.GetType().GetMethods(BINDING_ATTR)
                let attribute =
                    method
                        .GetCustomAttributes<MethodValidateAttribute>(true)
                        .SingleOrDefault()
                where attribute != null
                      && !method.GetParameters().Any()
                      && method.ReturnType == typeof(ValidationError)
                let result = (ValidationError)method.Invoke(obj, null)
                where result != null
                select result;

            return 
                propertiesValidationErrors
                    .Concat(methodsValidationErrors)
                    .Distinct();
        }

        private IEnumerable<ValidationError> GetPropertiesValidationErrors(object obj, BindingFlags bindingFlags)
        {
            Checker.ArgumentIsNull(obj, "obj");

            foreach (var property in obj.GetType().GetProperties(bindingFlags))
            {
                var validateAttribute =
                    property
                        .GetCustomAttributes<ValidateAttribute>(true)
                        .SingleOrDefault();
                if (validateAttribute != null)
                {
                    var value = property.GetValue(obj, null);

                    var isValid = validateAttribute.IsValid(value);

                    if (!isValid)
                        yield return new ValidationError(validateAttribute.Key ?? property.Name, validateAttribute.Message);
                }
                
                var validateComplexTypeAttribute = 
                    property
                        .GetCustomAttributes<ComplexTypeValidateAttribute>(true)
                        .SingleOrDefault();
                if (validateComplexTypeAttribute != null)
                {
                    var value = property.GetValue(obj, null);
                    if (value != null)
                    {
                        var collectionValues = value as IEnumerable;
                        if (collectionValues != null)
                        {
                            foreach (var collectionValue in collectionValues)
                            {
                                var validationErrors = GetValidationErrors(collectionValue);

                                foreach (var validationError in validationErrors)
                                    yield return validationError;
                            }
                        }
                        else
                        {
                            var validationErrors = GetValidationErrors(value);

                            foreach (var validationError in validationErrors)
                                yield return validationError;
                        }
                    }
                }
            }
        }
    }
}
