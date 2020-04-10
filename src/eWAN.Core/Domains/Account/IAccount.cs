namespace eWAN.Core.Domains.Account
{
    public interface IAccount
    {
        Name details { get; }
        UserContacts contacts { get; }
        UserGuardian guardian { get; }
    }
}
