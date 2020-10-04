namespace eWAN.Tests.Fakes
{
    using Application.Boundaries.LogIn;

    public class LogInPresenterFake : ILogInOutputPort
    {
        public LogInOutput StandardOutput { get; set; }
        public string ErrorOutput { get; set; }

        public void Standard(LogInOutput output) => StandardOutput = output;

        public void WriteError(string message) => ErrorOutput = message;
    }
}
