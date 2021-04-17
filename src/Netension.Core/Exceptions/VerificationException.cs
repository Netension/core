using System;
using System.Runtime.Serialization;

namespace Netension.Core.Exceptions
{
    [Serializable]
    public class VerificationException : Exception
    {
        public int Code { get; }

        public VerificationException(int code, string message)
            : base(message)
        {
            Code = code;
        }

        public VerificationException()
        {
        }

        protected VerificationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public VerificationException(string message)
            : base(message)
        {
        }

        public VerificationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
