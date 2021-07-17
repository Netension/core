using System;
using System.Runtime.Serialization;

namespace Netension
{
    [Serializable]
    public class VerificationException : System.Exception
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

        public VerificationException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
