using System;
using System.Linq;
using eWAN.Domains.User;

namespace eWAN.Infrastructure.Database.Entities
{
    public class Application : Domains.Application.Application
    {
        public Application() {}

        public Application(IUser applicant)
        {
            this.Id = RandomString(10);
            this.applicant = applicant;
            this.staff = null;
            this.isAccepted = false;
            this.reason = "";
        }

        public override string Id { get; set; }
        public override IUser applicant { get; set; }
        public override IUser staff { get; set; }
        public override bool isAccepted { get; set; }
        public override string reason { get; set; }

        // TODO: Move this to a separate Module/Class
        private Random random = new Random();
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    
    }

}
