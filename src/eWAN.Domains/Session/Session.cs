using System;
using eWAN.Domains.Room;
using eWAN.Domains.Subject;
using eWAN.Domains.User;

namespace eWAN.Domains.Session
{
    public abstract class Session : BaseEntity, ISession
    {
        public abstract string Code { get; set; }
        public abstract DayOfWeek Day { get; set; }
        public virtual IRoom Room { get; set; }
        public virtual IUser Instructor { get; set; }
        public abstract SessionType Type { get; set; }
        public abstract TimeSpan StartTime { get; set; }
        public abstract TimeSpan EndTime { get; set; }
        public virtual ISubject Subject { get; set; }
    }
}
