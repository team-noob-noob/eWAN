namespace eWAN.Core.Domains.Security
{
    public interface IUser
    {
        string username { get; }
        string password { get; }
    }
}
