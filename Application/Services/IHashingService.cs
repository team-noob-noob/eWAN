namespace eWAN.Application.Services
{
    public interface IHashingService
    {
        string Hash(string plainText);
        bool IsValid(string plainText, string hash);
    }
}
