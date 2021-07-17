using System;
using System.Collections.Generic;

namespace Netension
{
    public class ValidationFailure
    {
        public string Property { get; }
        public int Code { get; }
        public string Message { get; }

        public ValidationFailure(string property, int code, string message)
        {
            Property = property;
            Code = code;
            Message = message;
        }
    }


    [Serializable]
    public class ValidationException : System.Exception
    {
        public int Code { get; }
        public IEnumerable<ValidationFailure> Failures { get; }

        public ValidationException() { }
        public ValidationException(int code, IEnumerable<ValidationFailure> failures, string message)
            : base(message)
        {
            Code = code;
            Failures = failures;
        }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, System.Exception inner) : base(message, inner) { }
        protected ValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
