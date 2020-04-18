using System.Threading.Tasks;

namespace eWAN.Core.Application.Services
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
