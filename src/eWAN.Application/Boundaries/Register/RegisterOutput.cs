using eWAN.Domains.User;

namespace eWAN.Application.Boundaries.Register
{
    public class RegisterOutput
    {
        public RegisterOutput(IUser newUser)
        {
            this.newUser = newUser;
        }

        public IUser newUser { get; }
    }
}
