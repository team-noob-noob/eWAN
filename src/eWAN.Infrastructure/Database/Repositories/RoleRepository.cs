using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Role;
    using Domains.User;
    using Role = Entities.Role;

    public class RoleRepository : IRoleRepository
    {
        public RoleRepository(EwanContext context) => this._context = context ?? throw new ArgumentNullException(nameof(context));

        private EwanContext _context;


        public async Task Add(IRole newRole)
        {
            await this._context.UserRoles.AddAsync((Role) newRole);
            await this._context.SaveChangesAsync();
        }

        public List<IRole> GetRolesByUser(IUser user)
        {
            List<IRole> result = new List<IRole>();
            var query = this._context.UserRoles.Where(x => x.user.Username == user.Username && !x.isDeleted());
            foreach (IRole role in query)
                result.Add(role);
            return result;
        }

        public async Task Remove(IRole role)
        {
            role.deletedAt = DateTime.Now;
            await this._context.SaveChangesAsync();
        }
    }
}
