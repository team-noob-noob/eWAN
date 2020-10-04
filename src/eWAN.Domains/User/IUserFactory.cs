namespace eWAN.Domains.User
{
    public interface IUserFactory
    {
        IUser NewUser(
            string username,
            string password,
            string email,
            string phoneNumber,
            string firstName,
            string middleName,
            string lastName,
            string address);
    }
}
