using Netension.Core;

namespace Netension.Exception
{
    public class VerificationErrorEnumeration : Enumeration
    {
        public static VerificationErrorEnumeration NotFound => new VerificationErrorEnumeration(404, "NotFound", "{0}");
        public static VerificationErrorEnumeration Conflict => new VerificationErrorEnumeration(409, "Conflict", "{0}");

        public string Message { get; }

        public VerificationErrorEnumeration(int id, string name, string message)
            : base(id, name)
        {
            Message = message;
        }
    }
}
