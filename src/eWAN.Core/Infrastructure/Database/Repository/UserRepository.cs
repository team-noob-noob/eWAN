namespace eWAN.Core.Infrastructure.Database.Repositories
{
    using System.Threading.Tasks;
    using Domains.Security;
    using System.Linq;
    using User = Entities.User;
    using Microsoft.EntityFrameworkCore;

    public sealed class UserRepository : IUserRepository
    {
        private SchoolContext _context { get; }

        public UserRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task AddUser(IUser user)
        {
            await _context.users.AddAsync(user as User).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteUser(ExternalUserId externalUserId)
        {
            var user = await _context
                .users
                .Where(a => a.externalUserId.Equals(externalUserId))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);
            
            user.deletedAt = System.DateTime.Now;
        }

        public async Task<IUser> GetUser(ExternalUserId externalUserId)
        {
            var user = await _context
                .users
                .Where(a => a.externalUserId.Equals(externalUserId))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);
            
            if(user is null)
            {
                throw new System.Exception("The user is not found");
            }

            return user;
        }

        public async Task<IUser> GetUser(string username)
        {
            var user = await _context
                .users
                .Where(a => a.username.Equals(username))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);
            
            if(user is null)
            {
                throw new System.Exception("The user is not found");
            }

            return user;
        }
    }
}
