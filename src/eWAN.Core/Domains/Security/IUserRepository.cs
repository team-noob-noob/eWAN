using System.Threading.Tasks;

namespace eWAN.Core.Domains.Security
{
    public interface IUserRepository
    {
        Task AddUser(IUser user);
        Task<IUser> GetUser(ExternalUserId externalUserId);
        Task<IUser> GetUser(string username);
        Task DeleteUser(ExternalUserId externalUserId);
    }
}
