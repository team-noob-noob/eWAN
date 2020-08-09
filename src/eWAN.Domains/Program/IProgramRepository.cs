using System.Threading.Tasks;

namespace eWAN.Domains.Program
{
    public interface IProgramRepository
    {
        Task Add(IProgram program);
    }
}
