using System.Threading.Tasks;
using System.Linq;

namespace eWAN.Application.UseCases
{
    using Services;
    using Domains.Application;
    using Domains.Role;
    using Boundaries.ApplicationJurying;

    public class ApplicationJuryingUseCase : IApplicationJuryingUseCase
    {
        public ApplicationJuryingUseCase(
            IApplicationRepository applicationRepository,
            IApplicationJuryingOutputPort outputPort,
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork
        )
        {
            this._applicationRepository = applicationRepository;
            this._outputPort = outputPort;
            this._unitOfWork = unitOfWork;
            this._roleRepository = roleRepository;
        }

        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationJuryingOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;

        public async Task Handle(ApplicationJuryingInput input)
        {
            var studentApplication = this._applicationRepository.GetApplicationById(input.ApplicationId);

            if(studentApplication == null)
            {
                this._outputPort.WriteError("Invalid Application Id");
                return;
            }

            if(input.IsAccepted)
            {
                var oldStudentApplicantRole = this._roleRepository.GetRolesByUser(studentApplication.applicant).SingleOrDefault(x => x.role == UserRole.StudentApplicant);
                oldStudentApplicantRole.role = UserRole.Student;
            }

            studentApplication.isAccepted = input.IsAccepted;
            studentApplication.reason = input.Reason;
            studentApplication.staff = input.Jury;

            this._outputPort.Standard(new ApplicationJuryingOutput(studentApplication));

            await this._unitOfWork.Save();
        }
    }
}
