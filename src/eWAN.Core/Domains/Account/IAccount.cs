namespace eWAN.Core.Domains.Account
{
    public interface IAccount
    {
        AccountId accountId { get; }
        Name name { get; }
        Contact contacts { get; }
        Guardian guardian { get; }
    }
}
