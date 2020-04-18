using System.Threading.Tasks;

namespace eWAN.Core.Domains.Account
{
    public interface IAccountRepository
    {
        Task AddAccount(IAccount account);
    }
}
