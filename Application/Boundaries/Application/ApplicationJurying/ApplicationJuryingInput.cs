namespace eWAN.Application.Boundaries.ApplicationJurying
{
    using Domains.User;

    public class ApplicationJuryingInput
    {
        public ApplicationJuryingInput(
            string ApplicationId,
            IUser jury,
            bool isAccepted,
            string reason)
        {
            this.ApplicationId = ApplicationId;
            this.Jury = jury;
            this.IsAccepted = isAccepted;
            this.Reason = reason;
        }

        public string ApplicationId { get; }
        public IUser Jury { get; }
        public bool IsAccepted { get; }
        public string Reason { get; }
    }
}
