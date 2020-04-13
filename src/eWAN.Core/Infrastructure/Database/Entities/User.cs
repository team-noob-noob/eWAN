using System;
using eWAN.Core.Domains.Account;
using eWAN.Core.Domains.Security;

namespace eWAN.Core.Infrastructure.Database.Entities
{
    public class User : Domains.Security.User
    {
        public User(AccountId accountId, string username, string password)
        {
            this.externalUserId = new ExternalUserId(Guid.NewGuid()); 
            this.accountId = accountId;
            this.username = username;
            this.password = password;
        }
    }
}
