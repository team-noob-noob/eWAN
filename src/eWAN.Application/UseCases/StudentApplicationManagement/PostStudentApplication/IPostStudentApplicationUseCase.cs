using System.Threading.Tasks;

namespace eWAN.Application.UseCases.StudentApplicationManagement.PostStudentApplication
{
    public interface IPostStudentApplicationUseCase
    {
        Task Execute(PostStudentApplcationInput input);
        void SetOutputPort(IOutputPort port);
    }
}
