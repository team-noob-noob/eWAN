using eWAN.Core.Domains.Account;

namespace eWAN.Core.Domains.Security
{
    public interface IUserFactory
    {
        IUser NewUser(AccountId accountId, string username, string password);
    }
}
