using System.Threading.Tasks;

namespace eWAN.Application.UseCases
{
    using Services;
    using Domains.Application;
    using Boundaries.ApplicationJurying;

    public class ApplicationJuryingUseCase : IApplicationJuryingUseCase
    {
        public ApplicationJuryingUseCase(
            IApplicationRepository applicationRepository,
            IApplicationJuryingOutputPort outputPort,
            IUnitOfWork unitOfWork
        )
        {
            this._applicationRepository = applicationRepository;
            this._outputPort = outputPort;
            this._unitOfWork = unitOfWork;
        }

        private readonly IApplicationRepository _applicationRepository;
        private readonly IApplicationJuryingOutputPort _outputPort;
        private readonly IUnitOfWork _unitOfWork;

        public async Task Handle(ApplicationJuryingInput input)
        {
            var studentApplication = this._applicationRepository.GetApplicationById(input.ApplicationId);

            if(studentApplication == null)
            {
                this._outputPort.WriteError("Invalid Application Id");
                return;
            }

            studentApplication.isAccepted = input.IsAccepted;
            studentApplication.reason = input.Reason;
            studentApplication.staff = input.Jury;

            this._outputPort.Standard(new ApplicationJuryingOutput(studentApplication));

            await this._unitOfWork.Save();
        }
    }
}
