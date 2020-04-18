using eWAN.Core.Domains.Account;
using eWAN.Core.Domains.Security;

namespace eWAN.Core.Application.Boundaries.Register
{
    public class RegisterOutput
    {
        public RegisterOutput(Account account, User user)
        {
            this.user = user;
            this.account = account;
        }

        public Account account { get; }
        public User user { get; }
    }
}
