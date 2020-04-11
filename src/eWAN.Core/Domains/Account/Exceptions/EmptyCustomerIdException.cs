using System;

namespace eWAN.Core.Domains.Account
{
    internal sealed class EmptyAccountIdException : DomainException
    {
        internal EmptyAccountIdException(string message)
            : base(message) {}

        public EmptyAccountIdException() {}

        public EmptyAccountIdException(string message, Exception innerException)
            : base(message, innerException) {}
    }
}
