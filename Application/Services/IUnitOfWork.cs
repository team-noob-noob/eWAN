using System.Threading.Tasks;

namespace eWAN.Application.Services
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
