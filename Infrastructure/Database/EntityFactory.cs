namespace eWAN.Infrastructure.Database
{
    using Domains.User;
    using User = Entities.User;

    public class EntityFactory : IUserFactory
    {
        public IUser NewUser(
            string Username,
            string Password, 

            string Email, 
            string PhoneNumber, 

            string FirstName,
            string MiddleName,
            string LastName,

            string Address) => new User(
                Username, 
                Password,
                Email,
                PhoneNumber,
                FirstName,
                MiddleName,
                LastName,
                Address);
    }
}
