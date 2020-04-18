namespace eWAN.Core.Domains.Account
{
    public interface IAccountFactory
    {
        IAccount NewAccount(
            Contact contact,
            Guardian guardian,
            Name name
        );
    }
}
