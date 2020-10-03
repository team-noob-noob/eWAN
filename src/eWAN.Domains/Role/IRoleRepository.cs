using System.Collections.Generic;
using System.Threading.Tasks;

namespace eWAN.Domains.Role
{
    using User;

    public interface IRoleRepository
    {
        Task Add(IRole newRole);
        Task Remove(IRole role);
        List<IRole> GetRolesByUser(IUser user);
    }
}
