using Microsoft.AspNetCore.Identity;
using Sinuka.Core.Domains.Entities;
using Sinuka.Core.Infrastructure.Database;

namespace Sinuka.Core.Stores
{
    public class UserStore : Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<User, Role, SinukaDbContext, string, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
    {
        public UserStore(SinukaDbContext context, IdentityErrorDescriber describer = null) : base(context, describer) {}
    }
}
