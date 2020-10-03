using eWAN.Domains.User;

namespace eWAN.Domains.Application
{
    public abstract class Application : BaseEntity, IApplication
    {
        public abstract string Id { get; set; }
        public virtual IUser Applicant { get; set; } 
        public virtual IUser Staff { get; set; } 
        public abstract bool IsAccepted { get; set; } 
        public abstract string Reason { get; set; }
    }
}
