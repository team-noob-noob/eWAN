using System.Threading.Tasks;

namespace eWAN.Application.UseCases
{
    using Domains.User;
    using Application.Boundaries.Register;
    using Application.Services;

    public class RegisterUseCase : IRegisterUseCase
    {
        public RegisterUseCase(
            IRegisterOutputPort outputPort,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork
        )
        {
            this._outputPort = outputPort;
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        private readonly IRegisterOutputPort _outputPort;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task Handle(RegisterInput input)
        {
            if(input is null)
            {
                this._outputPort.WriteError("Input is null");
                return;
            }

            if(await this._userRepository.GetByUsername(input.Username) != null)
            {
                this._outputPort.WriteError("Username already taken");
                return;
            }

            IUser user = input;
            await this._userRepository.Add(user);
            await this._unitOfWork.Save();

            this._outputPort.Standard(new RegisterOutput(user));
        }
    }
}
