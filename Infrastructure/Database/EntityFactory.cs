namespace eWAN.Infrastructure.Database
{
    using Domains.User;
    using Domains.Role;
    using Domains.Application;
    using Role = Entities.Role;
    using User = Entities.User;
    using Application = Entities.Application;

    public class EntityFactory : IUserFactory, IRoleFactory, IApplicationFactory
    {
        public IApplication NewApplication(IUser applicant) => new Application(applicant);

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
