using System;

namespace eWAN.Core.Domains.Account
{
    internal class EmptyGuardianException : DomainException
    {
        internal EmptyGuardianException(string message)
            : base(message) {}

        public EmptyGuardianException() : base() {}

        internal EmptyGuardianException(string message, Exception innerException)
            : base(message, innerException) {}
    }
}
