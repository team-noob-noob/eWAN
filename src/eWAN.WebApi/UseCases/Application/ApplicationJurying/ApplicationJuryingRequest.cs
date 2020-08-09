namespace eWAN.WebApi.UseCases.ApplicationJurying
{
    public class ApplicationJuryingRequest
    {
        public string ApplicationId { get; }
        public bool IsAccepted { get; }
        public string Reason { get; }
    }
}
