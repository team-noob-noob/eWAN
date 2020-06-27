using System.Threading.Tasks;

namespace eWAN.Application.UseCases
{
    using Domains.User;
    using Domains.Role;
    using Application.Boundaries.Register;
    using Application.Services;

    public class RegisterUseCase : IRegisterUseCase
    {
        public RegisterUseCase(
            IRegisterOutputPort outputPort,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserFactory userFactory,
            IRoleFactory roleFactory,
            IUnitOfWork unitOfWork,
            IHashingService hashingService
        )
        {
            this._outputPort = outputPort;
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            this._userFactory = userFactory;
            this._roleFactory = roleFactory;
            this._unitOfWork = unitOfWork;
            this._hashingService = hashingService;
        }

        private readonly IRegisterOutputPort _outputPort;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserFactory _userFactory;
        private readonly IRoleFactory _roleFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashingService _hashingService;

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

            if(await this._userRepository.GetByEmail(input.Email) != null)
            {
                this._outputPort.WriteError("Email already taken");
                return;
            }

            IUser user = this._userFactory.NewUser(
                input.Username,
                this._hashingService.Hash(input.Password),
                input.Email,
                input.PhoneNumber,
                input.FirstName,
                input.MiddleName,
                input.LastName,
                input.Address);
            await this._userRepository.Add(user);

            IRole role = this._roleFactory.NewRole(user);
            await this._roleRepository.Add(role);

            await this._unitOfWork.Save();

            this._outputPort.Standard(new RegisterOutput(user));
        }
    }
}
