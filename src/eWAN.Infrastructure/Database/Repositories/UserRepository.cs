using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eWAN.Infrastructure.Database.Repositories
{
    using System.Threading.Tasks;
    using Domains.User;
    using User = Entities.User;

    public class UserRepository : IUserRepository
    {
        public UserRepository(EwanContext context) => this._context = context ?? throw new ArgumentNullException(nameof(context));

        private EwanContext _context;

        public async Task Add(IUser user)
        {
            await this._context.Users
            .AddAsync((User) user);
            await this._context
            .SaveChangesAsync();
        }

        public async Task<IUser> GetByUsername(string username)
        {
            User user = await this._context.Users
            .Where(a => a.Username == username && !a.isDeleted())
            .SingleOrDefaultAsync();

            return user;
        }

        public async Task<IUser> GetByEmail(string email)
        {
            User user = await this._context.Users
            .Where(a => a.Email == email && !a.isDeleted())
            .SingleOrDefaultAsync();
            return user;
        }

        public async Task<IUser> GetById(string Id)
        {
            var user = await this._context.Users
            .SingleOrDefaultAsync(a => a.Id == Id);
            return user;
        }
    }
}
