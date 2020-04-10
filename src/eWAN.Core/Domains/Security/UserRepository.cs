using System;
using System.Threading.Tasks;

namespace eWAN.Core.Domains.Security
{
    public interface IUserRepository
    {
        Task Add(IUser user);
        
    }
}
