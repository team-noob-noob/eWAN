using System.Linq;
using System.Threading.Tasks;

namespace eWAN.Tests.Fakes
{
    using Domains.User;
    using User = Infrastructure.Database.Entities.User;

    public class UserRepositoryFake : IUserRepository
    {
        public UserRepositoryFake(EwanContextFake context) => _context = context;

        private readonly EwanContextFake _context;

        public async Task Add(IUser user)
        {
            _context.Users.Add((User) user);
            await Task.CompletedTask.ConfigureAwait(false);
        }

        public async Task<IUser> GetByUsername(string username)
        {
            var user = _context.Users.SingleOrDefault(e => e.Username == username);
            if(user is null)
            {
                return null;
            }
            return await Task.FromResult(user);
        }

        public async Task<IUser> GetByEmail(string email)
        {
            var user = _context.Users.SingleOrDefault(e => e.Email == email);
            if(user is null)
            {
                return null;
            }
            return await Task.FromResult(user);
        }

        public async Task<IUser> GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(e => e.Id == id);
            if(user is null)
            {
                return null;
            }
            return await Task.FromResult(user);
        }
    }
}
