namespace eWAN.Application.Boundaries.ApplicationJurying
{
    using Domains.User;

    public class ApplicationJuryingInput
    {
        public ApplicationJuryingInput(
            string applicationId,
            IUser jury,
            bool isAccepted,
            string reason)
        {
            ApplicationId = applicationId;
            Jury = jury;
            IsAccepted = isAccepted;
            Reason = reason;
        }

        public string ApplicationId { get; }
        public IUser Jury { get; }
        public bool IsAccepted { get; }
        public string Reason { get; }
    }
}
