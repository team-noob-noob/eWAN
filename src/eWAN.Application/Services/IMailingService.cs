namespace eWAN.Application.Services
{
    public interface IMailingService
    {
        void SendMessage(string message, string emailAddress);
    }
}
