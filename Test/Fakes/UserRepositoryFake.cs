using System.Linq;
using System.Threading.Tasks;

namespace eWAN.Tests.Fakes
{
    using Domains.User;
    using User = Infrastructure.Database.Entities.User;

    public class UserRepositoryFake : IUserRepository
    {
        public UserRepositoryFake(EwanContextFake context) => this._context = context;

        private EwanContextFake _context;

        public async Task Add(IUser user)
        {
            this._context.Users.Add((User) user);
            await Task.CompletedTask.ConfigureAwait(false);
        }

        public async Task<IUser> GetByUsername(string username)
        {
            var user = this._context.Users.SingleOrDefault(e => e.Username == username);
            if(user is null)
            {
                return null;
            }
            return await Task.FromResult(user);
        }

        public async Task<IUser> GetByEmail(string email)
        {
            var user = this._context.Users.SingleOrDefault(e => e.Email == email);
            if(user is null)
            {
                return null;
            }
            return await Task.FromResult(user);
        }

        public async Task<IUser> GetById(string Id)
        {
            var user = this._context.Users.SingleOrDefault(e => e.Id == Id);
            if(user is null)
            {
                return null;
            }
            return await Task.FromResult(user);
        }
    }
}
