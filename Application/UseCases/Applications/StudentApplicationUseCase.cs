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
            this._applicationFactory = applicationFactory;
            this._applicationRepository = applicationRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = outputPort;
        }

        private readonly IApplicationFactory _applicationFactory;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentApplicationOutputPort _outputPort;

        public async Task Handle(StudentApplicationInput input)
        {
            var previousApplications = this._applicationRepository.GetApplicationsByApplicantId(input.applicant.Id);
            previousApplications.Sort((x, y) => y.createdAt.CompareTo(x.createdAt));

            if(previousApplications.Count >= 3)
            {
                this._outputPort.WriteError("User already surpassed the allowed limit of applications; User is only allowed maximum of 3 applications");
                return;
            }

            if(previousApplications.Count >= 1 ? this.IsDateTimeWithinSixMonthsFromNow(previousApplications[0].createdAt) : false)
            {
                this._outputPort.WriteError("User already applied within 6 months, please wait a while");
                return;
            }

            var newApplication = this._applicationFactory.NewApplication(input.applicant);

            await this._applicationRepository.Add(newApplication);

            this._outputPort.Standard(new StudentApplicationOutput(newApplication.Id));

            await this._unitOfWork.Save();
        }

        // TODO: Move to a proper class/lib
        private bool IsDateTimeWithinSixMonthsFromNow(DateTime date)
        {
            DateTime now = DateTime.Now;
            DateTime start = now.AddMonths(-6);
            DateTime end = now;

            return start <= date && date <= end;
        }
    }
}
