namespace eWAN.Tests.Mocks
{
    using System;
    using Domains.Application;
    using eWAN.Domains.User;

    public class ApplicationEntityMock : Application
    {
        public ApplicationEntityMock(DateTime createdAt = new DateTime())
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
