using System;
using System.Collections.Generic;

namespace Netension
{
    public class ValidationError
    {
        public string Property { get; }
        public int Code { get; }
        public string Message { get; }

        public ValidationError(string property, int code, string message)
        {
            Property = property;
            Code = code;
            Message = message;
        }
    }


    [Serializable]
    public class ValidationException : Exception
    {
        public int Code { get; }
        public IEnumerable<ValidationError> Errors { get; }

        public ValidationException() { }
        public ValidationException(int code, IEnumerable<ValidationError> errors, string message)
            : base(message)
        {
            Code = code;
            Errors = errors;
        }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception inner) : base(message, inner) { }
        protected ValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
