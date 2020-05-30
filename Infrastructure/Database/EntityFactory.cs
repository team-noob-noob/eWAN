namespace eWAN.Infrastructure.Database
{
    using Domains.User;
    using User = Entities.User;

    public class EntityFactory : IUserFactory
    {
        public IUser NewUser(string Username, string Password) => new User(Username, Password);
    }
}
