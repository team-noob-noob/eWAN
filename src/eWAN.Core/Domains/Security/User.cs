using eWAN.Core.Domains.Account;

namespace eWAN.Core.Domains.Security
{
    public abstract class User : BaseEntity, IUser
    {
        public AccountId accountId { get; protected set; }
        public ExternalUserId externalUserId { get; protected set; }
        public string username { get; protected set; }
        public string password { get; protected set; }
    }
}
