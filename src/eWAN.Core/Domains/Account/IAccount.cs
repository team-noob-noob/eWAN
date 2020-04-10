namespace eWAN.Core.Domains.Account
{
    public interface IAccount
    {
        UserDetails details { get; }
        UserContacts contacts { get; }
        UserGuardian guardian { get; }
    }
}
