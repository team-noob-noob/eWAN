using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace eWAN.Tests.Fakes
{
    using Domains.Role;
    using Domains.User;
    using Role = Infrastructure.Database.Entities.Role;

    public class RoleRepositoryFake : IRoleRepository
    {
        public RoleRepositoryFake(EwanContextFake context) => _context = context;

        private readonly EwanContextFake _context;

        public async Task Add(IRole newRole)
        {
            _context.UserRoles.Add((Role) newRole);
            await Task.CompletedTask;
        }

        public List<IRole> GetRolesByUser(IUser user)
        {
            List<IRole> result = new List<IRole>();
            var query = _context.UserRoles.Where(x => x.User.Username == user.Username);
            foreach (IRole role in query)
                result.Add(role);
            return result;
        }

        public async Task Remove(IRole role)
        {
            _context.UserRoles.Remove((Role) role);
            await Task.CompletedTask;
        }
    }
}
