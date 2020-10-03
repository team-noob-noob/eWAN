using System.Threading.Tasks;

namespace eWAN.Application.Boundaries
{
    public interface IUseCase<in TUseCaseInput>
    {
        Task Handle(TUseCaseInput input);
    }
}
