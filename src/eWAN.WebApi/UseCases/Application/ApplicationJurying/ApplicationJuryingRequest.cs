namespace eWAN.WebApi.UseCases.ApplicationJurying
{
    public class ApplicationJuryingRequest
    {
        public string ApplicationId { get; set; }
        public bool IsAccepted { get; set; }
        public string Reason { get; set; }
    }
}
