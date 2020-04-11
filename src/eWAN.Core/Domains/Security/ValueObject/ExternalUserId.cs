using System;
using System.Collections.Generic;

namespace eWAN.Core.Domains.Security
{
    public class ExternalUserId : ValueObject
    {
        public Guid externalUserId { get; protected set; }

        private ExternalUserId() {}
        public ExternalUserId(Guid externalUserId)
        {
            this.externalUserId = externalUserId;
        }

        public Guid ToGuid() => externalUserId;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return externalUserId;
        }
    }
}
