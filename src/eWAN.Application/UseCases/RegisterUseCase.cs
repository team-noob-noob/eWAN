using System.Threading.Tasks;

namespace eWAN.Application.UseCases
{
    using Domains.User;
    using Domains.Role;
    using Boundaries.Register;
    using Services;

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
            _outputPort = outputPort;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userFactory = userFactory;
            _roleFactory = roleFactory;
            _unitOfWork = unitOfWork;
            _hashingService = hashingService;
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
                _outputPort.WriteError("Input is null");
                return;
            }

            if(await _userRepository.GetByUsername(input.Username) != null)
            {
                _outputPort.WriteError("Username already taken");
                return;
            }

            if(await _userRepository.GetByEmail(input.Email) != null)
            {
                _outputPort.WriteError("Email already taken");
                return;
            }

            IUser user = _userFactory.NewUser(
                input.Username,
                _hashingService.Hash(input.Password),
                input.Email,
                input.PhoneNumber,
                input.FirstName,
                input.MiddleName,
                input.LastName,
                input.Address);
            await _userRepository.Add(user);

            IRole role = _roleFactory.NewRole(user);
            await _roleRepository.Add(role);

            await _unitOfWork.Save();

            _outputPort.Standard(new RegisterOutput(user));
        }
    }
}
