namespace eWAN.Tests.Mocks
{
    using System;
    using Domains.Application;
    using Domains.User;

    public class ApplicationEntityMock : Application
    {
        public ApplicationEntityMock(DateTime createdAt = new DateTime())
        {
            this.CreatedAt = createdAt;
        }

        public override IUser Applicant { get; set; }
        public override IUser Staff { get; set; }
        public override bool IsAccepted { get; set; }
        public override string Reason { get; set; }
        public override DateTime CreatedAt { get; protected set; }
        public override string PublicId { get; set; }
    }
}
