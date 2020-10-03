namespace eWAN.Tests.Fakes
{
    using Application.Boundaries.Register;

    public class RegisterPresenterFake : IRegisterOutputPort
    {
        public RegisterOutput StandardOutput { get; set; }
        public string ErrorOutput { get; set; }

        public void Standard(RegisterOutput output) => StandardOutput = output;

        public void WriteError(string message) => ErrorOutput = message;
    }
}
