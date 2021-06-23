using Netension.Core.Enumerations;

namespace Netension.Core.Exceptions
{
    public class NotFoundException : VerificationException
    {
        public NotFoundException(string message)
            : base(VerificationErrorEnumeration.NotFound.Id, string.Format(VerificationErrorEnumeration.NotFound.Message, message))
        {

        }
    }
}
