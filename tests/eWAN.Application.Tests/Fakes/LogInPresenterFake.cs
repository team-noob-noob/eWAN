namespace eWAN.Tests.Fakes
{
    using Application.Boundaries.LogIn;

    public class LogInPresenterFake : ILogInOutputPort
    {
        public LogInOutput StandardOutput { get; set; }
        public string ErrorOutput { get; set; }

        public void Standard(LogInOutput output) => this.StandardOutput = output;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
