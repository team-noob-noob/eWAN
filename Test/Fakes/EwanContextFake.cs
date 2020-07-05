using System.Collections.ObjectModel;

namespace eWAN.Tests.Fakes
{
    using Mocks;
    using Infrastructure.Database.Entities;
    using Infrastructure.Hashing;
    using UserRole = Domains.Role.UserRole;

    public sealed class EwanContextFake
    {
        public EwanContextFake()
        {
            var hashingService = new BcryptHashing();

            var user = new User(
                "testing",
                hashingService.Hash("testing"),
                "testing@testing.testing3",
                "0900000000",
                "testing",
                "testing",
                "testing",
                "testing"
            );
            this.Users.Add(user);
            this.Users.Add(TestUser);
            this.Users.Add(TestUser2);

            var role = new Role(user, UserRole.StudentApplicant);
            this.UserRoles.Add(role);

            this.Applications.Add(TestApplication);
        }

        public readonly Collection<User> Users = new Collection<User>();
        public readonly Collection<Role> UserRoles = new Collection<Role>();
        public readonly Collection<Application> Applications = new Collection<Application>();

        public static User TestUser = new User(
            "testing123",
            new BcryptHashing().Hash("testing"),
            "testing@testing.testing",
            "0900000000",
            "testing",
            "testing",
            "testing",
            "testing"
        );

        public static User TestUser2 = new User(
            "testing123123",
            new BcryptHashing().Hash("testing"),
            "testing@testing.testing123",
            "0900000000",
            "testing",
            "testing",
            "testing",
            "testing"
        );

        public static Application TestApplication = new Application(TestUser);
    }
}
