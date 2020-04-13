using System.Threading.Tasks;

namespace eWAN.Core.Application.Boundaries
{
    public interface IUseCase<in TUseCaseInput>
    {
        Task Execute(TUseCaseInput input);
    }
}
