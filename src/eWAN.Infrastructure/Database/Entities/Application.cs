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
            this.PublicId = new Random().NewString();
            this.Applicant = applicant;
            this.Staff = null;
            this.IsAccepted = false;
            this.Reason = "";
        }

        public override bool IsAccepted { get; set; }
        public override string Reason { get; set; }
        public int? Applicant_Id { get; set; }
        public int? Staff_Id { get; set; }
        public override string PublicId { get; set; }
    }

}
