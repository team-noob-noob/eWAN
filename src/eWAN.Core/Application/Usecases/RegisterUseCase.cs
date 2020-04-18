namespace eWAN.Core.Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.Register;
    using Application.Services;
    using Domains.Security;
    using Domains.Account;

    public abstract class RegisterUseCase : IUseCase
    {
        public IOutputPort _output { get; }
        private IUnitOfWork _unitOfWork { get; }
        private IUserRepository _userRepository { get; }
        private IAccountRepository _accountRepository { get; }
        private IUserFactory _userFactory { get; }
        private IAccountFactory _accountFactory { get; }

        public RegisterUseCase(
            IOutputPort outputPort,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IAccountRepository accountRepository,
            IAccountFactory accountFactory,
            IUserFactory userFactory
        ) {
            _output = outputPort;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _accountFactory = accountFactory;
            _userFactory = userFactory;
        }

        public async Task Execute(RegisterInput input)
        {
            if(input is null)
            {
                _output.WriteError("Input is empty");
                return;
            }

            if(await _userRepository.GetUser(input.username).ConfigureAwait(false) != null)
            {
                _output.WriteError("Username is already taken");
                return;
            }

            IAccount account = _accountFactory.NewAccount(input.contact, input.guardian, input.name);
            IUser user = _userFactory.NewUser(account.accountId, input.username, input.password);

            await _accountRepository.AddAccount(account).ConfigureAwait(false);
            await _userRepository.AddUser(user).ConfigureAwait(false);

            await _unitOfWork.Save().ConfigureAwait(false);

            BuildOutput(account, user);
        }

        public void BuildOutput(IAccount account, IUser user)
        {
            var output = new RegisterOutput(account as Account, user as User);
            _output.Standard(output);
        }
    }
}
