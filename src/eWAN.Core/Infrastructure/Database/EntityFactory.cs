namespace eWAN.Core.Infrastructure.Database
{
    using Domains.Account;
    using Domains.Security;
    using Account = Entities.Account;
    using User = Entities.User;


    public class EntityFactory : IAccountFactory, IUserFactory
    {
        public IAccount NewAccount(Contact contact, Guardian guardian, Name name)
            => new Account(name, guardian, contact);

        public IUser NewUser(AccountId accountId, string username, string password)
            => new User(accountId, username, password);
    }
}
