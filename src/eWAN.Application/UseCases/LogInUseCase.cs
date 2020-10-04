namespace eWAN.Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.LogIn;
    using Domains.User;
    using Services;

    public class LogInUseCase : ILogInUseCase
    {
        public LogInUseCase(
            ILogInOutputPort output,
            IUserRepository userRepository,
            IHashingService hashingService
        )
        {
            _output = output;
            _userRepository = userRepository;
            _hashingService = hashingService;
        }

        private readonly ILogInOutputPort _output;
        private readonly IUserRepository _userRepository;
        private readonly IHashingService _hashingService;

        public async Task Handle(LogInInput input)
        {
            if(input is null)
            {
                _output.WriteError("Input is null");
                return;
            }

            if(input.Username == string.Empty || input.Password == string.Empty)
            {
                _output.WriteError("Username or Password is empty");
                return;
            }

            IUser user = await _userRepository.GetByUsername(input.Username);
            if(user is null || !_hashingService.IsValid(input.Password, user.Password))
            {
                _output.WriteError("Incorrect Username or Password");
                return;
            }

            _output.Standard(new LogInOutput(user));
        }
    }
}
