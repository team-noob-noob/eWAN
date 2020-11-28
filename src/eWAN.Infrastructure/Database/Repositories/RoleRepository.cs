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
            return user.AssignedRoles.Where(x => x.DeletedAt == null).ToList();
        }

        public async Task Remove(IRole role)
        {
            role.DeletedAt = DateTime.Now;
            await this._context.SaveChangesAsync();
        }
    }
}
