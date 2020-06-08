namespace eWAN.Infrastructure.Database
{
    using Domains.User;
    using Domains.Role;
    using Role = Entities.Role;
    using User = Entities.User;

    public class EntityFactory : IUserFactory, IRoleFactory
    {
        public IRole NewRole(IUser user, UserRole role = UserRole.StudentApplicant) => new Role(user, role);

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
