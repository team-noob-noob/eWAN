namespace eWAN.Domains.User
{
    public interface IUserFactory
    {
        IUser NewUser(string Username, string Password);
    }
}
