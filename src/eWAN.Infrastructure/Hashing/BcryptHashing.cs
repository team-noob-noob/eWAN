namespace eWAN.Infrastructure.Hashing
{
    using Application.Services;

    public class BcryptHashing : IHashingService
    {
        public string Hash(string plainText)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(plainText, 11);       
        }

        public bool IsValid(string plainText, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(plainText, hash);
        }
    }
}
