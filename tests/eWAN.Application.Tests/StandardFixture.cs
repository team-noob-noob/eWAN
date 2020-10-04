using System;

namespace eWAN.Tests
{
    using Fakes;
    using Infrastructure.Database;
    using Infrastructure.Hashing;

    public class StandardFixture : IDisposable
    {
        public StandardFixture()
        {
            Dispose();
        }

        public ApplicationRepositoryFake ApplicationRepositoryFake { get; set; }
        public EwanContextFake EwanContextFake { get; set; }
        public RoleRepositoryFake RoleRepositoryFake { get; set; }
        public UnitOfWorkFake UnitOfWorkFake { get; set; }
        public UserRepositoryFake UserRepositoryFake { get; set; }
        public EntityFactory EntityFactory { get; set; }
        public BcryptHashing BcryptHashing { get; set; }
        public CourseRepositoryFake CourseRepositoryFake { get; set; }
        public ProgramRepositoryFake ProgramRepositoryFake { get; set; }
        public RoomRepositoryFake RoomRepositoryFake { get; set; }

        public void Dispose()
        {
            EwanContextFake = new EwanContextFake();
            UnitOfWorkFake = new UnitOfWorkFake();
            EntityFactory = new EntityFactory();
            BcryptHashing = new BcryptHashing();
            ApplicationRepositoryFake = new ApplicationRepositoryFake(EwanContextFake);
            RoleRepositoryFake = new RoleRepositoryFake(EwanContextFake);
            UserRepositoryFake = new UserRepositoryFake(EwanContextFake);
            CourseRepositoryFake = new CourseRepositoryFake(EwanContextFake);
            ProgramRepositoryFake = new ProgramRepositoryFake(EwanContextFake);
            RoomRepositoryFake = new RoomRepositoryFake(EwanContextFake);
        }
    }
}
