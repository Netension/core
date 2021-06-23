using Netension.Core.Enumerations;

namespace Netension.Core.Exceptions
{
    public class ConflictException : VerificationException
    {
        public ConflictException(string message)
            : base(VerificationErrorEnumeration.Conflict.Id, string.Format(VerificationErrorEnumeration.Conflict.Message, message))
        {

        }
    }
}
