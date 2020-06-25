using System;

namespace eWAN.Tests.Mocks
{
    using Domains.Application;
    using Domains.User;

    public class MockedApplicationEntity : Application
    {
        public MockedApplicationEntity(DateTime createdAt = new DateTime()) : base()
        {
            this.createdAt = createdAt;
        }

        public override string Id { get; set; }
        public override IUser applicant { get; set; }
        public override IUser staff { get; set; }
        public override bool isAccepted { get; set; }
        public override string reason { get; set; }
        public override DateTime createdAt { get; protected set; }
    }
}
