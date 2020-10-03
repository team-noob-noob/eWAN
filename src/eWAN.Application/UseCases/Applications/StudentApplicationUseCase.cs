using System;
using System.Threading.Tasks;

namespace eWAN.Application.UseCases
{
    using Domains.Application;
    using Boundaries.StudentApplication;
    using Services;

    public class StudentApplicationUseCase : IStudentApplicationUseCase
    {
        public StudentApplicationUseCase(
            IApplicationFactory applicationFactory,
            IApplicationRepository applicationRepository,
            IUnitOfWork unitOfWork,
            IStudentApplicationOutputPort outputPort
        )
        {
            _applicationFactory = applicationFactory;
            _applicationRepository = applicationRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        private readonly IApplicationFactory _applicationFactory;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentApplicationOutputPort _outputPort;

        public async Task Handle(StudentApplicationInput input)
        {
            var previousApplications = _applicationRepository.GetApplicationsByApplicantId(input.Applicant.Id);
            previousApplications.Sort((x, y) => y.CreatedAt.CompareTo(x.CreatedAt));

            if(previousApplications.Count >= 3)
            {
                _outputPort.WriteError("User already surpassed the allowed limit of applications; User is only allowed maximum of 3 applications");
                return;
            }

            if(previousApplications.Count >= 1 && IsDateTimeWithinSixMonthsFromNow(previousApplications[0].CreatedAt))
            {
                _outputPort.WriteError("User already applied within 6 months, please wait a while");
                return;
            }

            var newApplication = _applicationFactory.NewApplication(input.Applicant);

            await _applicationRepository.Add(newApplication);

            _outputPort.Standard(new StudentApplicationOutput(newApplication.Id));

            await _unitOfWork.Save();
        }

        // TODO: Move to a proper class/lib
        private static bool IsDateTimeWithinSixMonthsFromNow(DateTime date)
        {
            DateTime now = DateTime.Now;
            DateTime start = now.AddMonths(-6);
            DateTime end = now;

            return start <= date && date <= end;
        }
    }
}
