using Netension.Exception;

namespace Netension
{
    public class NotFoundException : VerificationException
    {
        public NotFoundException(string message)
            : base(VerificationErrorEnumeration.NotFound.Id, string.Format(VerificationErrorEnumeration.NotFound.Message, message))
        {

        }

        public NotFoundException(int code, string message) : base(code, message)
        {
        }

        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
