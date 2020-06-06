namespace eWAN.Application.UseCases
{
    using System.Threading.Tasks;
    using Boundaries.LogIn;
    using Domains.User;

    public class LogInUseCase : ILogInUseCase
    {
        public LogInUseCase(
            ILogInOutputPort output,
            IUserRepository userRepository
        )
        {
            this._output = output;
            this._userRepository = userRepository;
        }

        private readonly ILogInOutputPort _output;
        private readonly IUserRepository _userRepository;

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
            if(user is null || user.Password != input.Password)
            {
                this._output.WriteError("Incorrect Username or Password");
                return;
            }

            // TODO: Add session key generation
            string SessionKey = "Testing SEssion - " + user.Username;

            this._output.Standard(new LogInOutput(SessionKey));
        }
    }
}
