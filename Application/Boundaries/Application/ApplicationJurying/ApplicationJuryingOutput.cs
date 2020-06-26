namespace eWAN.Application.Boundaries.ApplicationJurying
{
    using Domains.Application;

    public class ApplicationJuryingOutput
    {
        public ApplicationJuryingOutput(IApplication result)
        {
            this.StudentApplicationResult = result;
        }

        public IApplication StudentApplicationResult { get; }
    }
}
