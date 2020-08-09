namespace eWAN.Application.Services
{
    public interface IMailingService
    {
        void SendMessage(string Message, string EmailAddress);
    }
}
