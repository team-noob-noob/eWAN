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
            this.Dispose();
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
            this.EwanContextFake = new EwanContextFake();
            this.UnitOfWorkFake = new UnitOfWorkFake();
            this.EntityFactory = new EntityFactory();
            this.BcryptHashing = new BcryptHashing();
            this.ApplicationRepositoryFake = new ApplicationRepositoryFake(this.EwanContextFake);
            this.RoleRepositoryFake = new RoleRepositoryFake(this.EwanContextFake);
            this.UserRepositoryFake = new UserRepositoryFake(this.EwanContextFake);
            this.CourseRepositoryFake = new CourseRepositoryFake(this.EwanContextFake);
            this.ProgramRepositoryFake = new ProgramRepositoryFake(this.EwanContextFake);
            this.RoomRepositoryFake = new RoomRepositoryFake(this.EwanContextFake);
        }
    }
}
