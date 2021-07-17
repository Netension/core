using Netension.Error;

namespace Netension
{
    public class ConflictException : VerificationException
    {
        public ConflictException(string message)
            : base(VerificationErrorEnumeration.Conflict.Id, string.Format(VerificationErrorEnumeration.Conflict.Message, message))
        {

        }

        public ConflictException(int code, string message) : base(code, message)
        {
        }

        public ConflictException() : base()
        {
        }

        public ConflictException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
