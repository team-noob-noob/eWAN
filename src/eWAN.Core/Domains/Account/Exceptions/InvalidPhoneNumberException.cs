using System;

namespace eWAN.Core.Domains.Account
{
    internal sealed class InvalidPhoneNumberException : DomainException
    {
        internal InvalidPhoneNumberException(string message)
            : base(message) {}
        
        public InvalidPhoneNumberException() : base() {}

        public InvalidPhoneNumberException(string message, Exception innerException)
            : base(message, innerException) {}
    }
}
