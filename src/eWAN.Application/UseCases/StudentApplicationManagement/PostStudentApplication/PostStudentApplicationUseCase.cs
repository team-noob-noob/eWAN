using System.Threading.Tasks;
using eWAN.Core.Domains.Interfaces.Repositories;

namespace eWAN.Application.UseCases.StudentApplicationManagement.PostStudentApplication
{
    public class PostStudentApplicationUseCase : IPostStudentApplicationUseCase
    {
        private readonly IStudentApplicationRepository _studentApplicationRepo;
        private IOutputPort _outputPort;

        public async Task Execute(PostStudentApplcationInput input)
        {
            
        }

        public void SetOutputPort(IOutputPort port) => this._outputPort = port;
    }
}
