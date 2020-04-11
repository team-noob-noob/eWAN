using eWAN.Core.Domains.Account;

namespace eWAN.Core.Domains.Security
{
    public interface IUser
    {
        AccountId accountId { get; }
        ExternalUserId externalUserId { get; }
        string username { get; }
        string password { get; }
    }
}
