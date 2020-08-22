using System;
using eWAN.Domains.User;

namespace eWAN.Domains.Application
{
    public abstract class Application : BaseEntity, IApplication
    {
        public abstract string Id { get; set; }
        public virtual IUser applicant { get; set; } 
        public virtual IUser staff { get; set; } 
        public abstract bool isAccepted { get; set; } 
        public abstract string reason { get; set; }
    }
}