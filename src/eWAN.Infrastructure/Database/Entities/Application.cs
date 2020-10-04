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
            
            this.Id = new Random().NewString();
            this.Applicant = applicant;
            this.Staff = null;
            this.IsAccepted = false;
            this.Reason = "";
        }

        public override string Id { get; set; }
        public override bool IsAccepted { get; set; }
        public override string Reason { get; set; }
        public string? Applicant_Id { get; set; }
        public string? Staff_Id { get; set; }
    }

}
