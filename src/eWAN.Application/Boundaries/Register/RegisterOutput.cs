using eWAN.Domains.User;

namespace eWAN.Application.Boundaries.Register
{
    public class RegisterOutput
    {
        public RegisterOutput(IUser newUser)
        {
            NewUser = newUser;
        }

        public IUser NewUser { get; }
    }
}
