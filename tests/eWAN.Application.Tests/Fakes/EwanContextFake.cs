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
            Users.Add(user);
            Users.Add(TestUser);
            Users.Add(TestUser2);

            var role = new Role(user, UserRole.StudentApplicant);
            UserRoles.Add(role);

            Applications.Add(TestApplication);

            Programs.Add(TestProgram);

            Courses.Add(TestCourse);

            Rooms.Add(TestRoom);
        }

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

        public static Program TestProgram = new Program("Bachelor of Science in Information Technology", "BSIT", "Tech", null);

        public static Course TestCourse = new Course("ITEC101", "Introduction to Computing", "Intro", null, TestProgram);

        public static Room TestRoom = new Room("101", "1st Floor - Room 1", "Found at Building 1");

        public readonly Collection<User> Users = new Collection<User>();
        public readonly Collection<Role> UserRoles = new Collection<Role>();
        public readonly Collection<Application> Applications = new Collection<Application>();
        public readonly Collection<Course> Courses = new Collection<Course>();
        public readonly Collection<Program> Programs = new Collection<Program>();
        public readonly Collection<Room> Rooms = new Collection<Room>();
    }
}
