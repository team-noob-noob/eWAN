using eWAN.Core.Domains;

namespace eWAN.Core.Domains.Account
{
    public class Account : BaseEntity, IAccount
    {
        public AccountId accountId { get; protected set; }
        public Name name { get; protected set; }
        public Contact contacts { get; protected set; }
        public Guardian guardian { get; protected set; }
    }
}
