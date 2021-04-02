namespace Netension.Core.Enumerations
{
    public class VerificationErrorEnumeration : Enumeration
    {
        public string Message { get; }

        public VerificationErrorEnumeration(int id, string name, string message) 
            : base(id, name)
        {
            Message = message;
        }
    }
}
