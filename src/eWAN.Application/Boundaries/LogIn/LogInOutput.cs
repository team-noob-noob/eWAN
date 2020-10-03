namespace eWAN.Application.Boundaries.LogIn
{
    using Domains.User;

    public class LogInOutput
    {
        public LogInOutput(IUser user)
        {
            User = user;
        }

        public IUser User { get; }
    }
}
