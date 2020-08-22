using System.Threading.Tasks;

namespace eWAN.Domains.User
{
    public interface IUserRepository
    {
        Task Add(IUser user);
        Task<IUser> GetByUsername(string username);
        Task<IUser> GetByEmail(string email);
        Task<IUser> GetById(string Id);
    }
}