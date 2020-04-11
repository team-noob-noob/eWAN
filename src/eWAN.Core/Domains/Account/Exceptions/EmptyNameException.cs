using System;

namespace eWAN.Core.Domains.Account
{
    internal sealed class EmptyNameException : DomainException
    {
        public EmptyNameException() {}

        internal EmptyNameException(string message)
            : base(message) {}

        internal EmptyNameException(string message, Exception innerException)
            : base(message, innerException) {}
    }
}
