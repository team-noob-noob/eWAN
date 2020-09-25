using System;
using eWAN.Domains.User;

namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.Application;

    public class Application : Domains.Application.Application, IApplication
    {
        public Application() {}

        public Application(IUser applicant)
        {
            Random rand = new Random();
            this.Id = rand.NewString(10);
            this.applicant = applicant;
            this.staff = null;
            this.isAccepted = false;
            this.reason = "";
        }

        public override string Id { get; set; }
        public override bool isAccepted { get; set; }
        public override string reason { get; set; }
        public string? Applicant_Id { get; set; }
        public string? Staff_Id { get; set; }
    }

}
