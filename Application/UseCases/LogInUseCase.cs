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
            this._output = output;
            this._userRepository = userRepository;
            this._hashingService = hashingService;
        }

        private readonly ILogInOutputPort _output;
        private readonly IUserRepository _userRepository;
        private readonly IHashingService _hashingService;

        public async Task Handle(LogInInput input)
        {
            if(input is null)
            {
                this._output.WriteError("Input is null");
                return;
            }

            if(input.Username == string.Empty || input.Password == string.Empty)
            {
                this._output.WriteError("Username or Password is empty");
                return;
            }

            IUser user = await this._userRepository.GetByUsername(input.Username);
            if(user is null || !this._hashingService.IsValid(input.Password, user.Password))
            {
                this._output.WriteError("Incorrect Username or Password");
                return;
            }

            this._output.Standard(new LogInOutput(user));
        }
    }
}
