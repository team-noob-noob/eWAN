using System;
using eWAN.Domains.Room;
using eWAN.Domains.User;

namespace eWAN.Domains.Session
{
    public abstract class Session : BaseEntity, ISession
    {
        public abstract string Id { get; set; }
        public abstract DayOfWeek Day { get; set; }
        public abstract IRoom Room { get; set; }
        public abstract IUser Instructor { get; set; }
        public abstract SessionType Type { get; set; }
        public abstract TimeSpan StartTime { get; set; }
        public abstract TimeSpan EndTime { get; set; }
    }
}
