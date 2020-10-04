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
            _applicationRepository = applicationRepository;
            _outputPort = outputPort;
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
        }

        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationJuryingOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;

        public async Task Handle(ApplicationJuryingInput input)
        {
            var studentApplication = _applicationRepository.GetApplicationById(input.ApplicationId);

            if(studentApplication == null)
            {
                _outputPort.WriteError("Invalid Application Id");
                return;
            }

            if(input.IsAccepted)
            {
                var oldStudentApplicantRole = _roleRepository.GetRolesByUser(studentApplication.Applicant).SingleOrDefault(x => x.UserRole == UserRole.StudentApplicant);
                oldStudentApplicantRole.UserRole = UserRole.Student;
            }

            studentApplication.IsAccepted = input.IsAccepted;
            studentApplication.Reason = input.Reason;
            studentApplication.Staff = input.Jury;

            _outputPort.Standard(new ApplicationJuryingOutput(studentApplication));

            await _unitOfWork.Save();
        }
    }
}
