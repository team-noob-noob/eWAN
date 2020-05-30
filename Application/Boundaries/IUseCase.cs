using System.Threading.Tasks;

namespace eWAN.Application.Boundaries
{
    public interface IUseCase<TUseCaseInput>
    {
        Task Handle(TUseCaseInput input);
    }
}
