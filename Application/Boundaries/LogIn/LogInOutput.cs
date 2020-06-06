namespace eWAN.Application.Boundaries.LogIn
{
    public class LogInOutput
    {
        public LogInOutput(string SessionString)
        {
            this.SessionString = SessionString;
        }

        public string SessionString { get; }
    }
}
