namespace eWAN.Tests.Fakes
{
    using Application.Boundaries.ApplicationJurying;

    public class ApplicationJuryingPresenterFake : IApplicationJuryingOutputPort
    {
        public ApplicationJuryingOutput StandardOutput { get; set; }
        public string ErrorOutput { get; set; }

        public void Standard(ApplicationJuryingOutput output) => this.StandardOutput = output;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
