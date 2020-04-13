using eWAN.Core.Domains.Account;

namespace eWAN.Core.Infrastructure.Database.Entities
{
    public class Account : Domains.Account.Account
    {
        public Account(Name name, Guardian guardian, Contact contact)
        {
            this.accountId = new AccountId(RandomGenerator.RandomIdString(10));
            this.guardian = guardian;
            this.name = name;
            this.contacts = contact;
        }
    }
}
