namespace eWAN.Application.Boundaries.LogIn
{
    using Domains.User;

    public class LogInOutput
    {
        public LogInOutput(IUser user)
        {
            this.user = user;
        }

        public IUser user { get; }
    }
}
