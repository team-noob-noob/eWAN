using System;
using System.Collections.Generic;

namespace eWAN.Core.Domains.Account
{
    public class AccountId : ValueObject
    {
        public string accountId; 

        public AccountId(string accountId)
        {
            if(this.accountId == string.Empty)
            {
                throw new EmptyAccountIdException();
            }

            this.accountId = accountId;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return accountId;
        }
    }
}
