using System.Threading.Tasks;
using eWAN.Core.Domains.Account;

namespace eWAN.Core.Domains.Security
{
    public interface IUserRepository
    {
        Task NewUser(AccountId accountId, string username, string password);
    }
}
