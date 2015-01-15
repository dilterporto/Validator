using System;
using Validator.Helpers;

namespace Validator
{
    /// <summary>Validation error</summary>
    public class ValidationError: IEquatable<ValidationError>
    {
        /// <summary>Constructor</summary>
        /// <param name="key">Validation key</param>
        /// <param name="message">Validation message</param>
        public ValidationError(string key, string message)
        {
            Checker.ArgumentIsWhitespace(key, "key");
            Checker.ArgumentIsWhitespace(message, "message");

            Key = key;
            Message = message;
        }

        /// <summary>Validation key</summary>
        public string Key { get; private set; }

        /// <summary>Validation message</summary>
        public string Message { get; private set; }

        /// <summary>Determines whether the specified System.Object is equal to the current System.Object</summary>
        public override bool Equals(object obj)
        {
            return Equals(obj as ValidationError);
        }

        /// <summary>Serves as a hash function for thr type</summary>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Key.GetHashCode() * 397) ^ Message.GetHashCode();
            }
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type</summary>
        public bool Equals(ValidationError other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Equals(Key, other.Key) && string.Equals(Message, other.Message);
        }
    }
}
