namespace eWAN.Infrastructure.Database.Entities
{
    using System;
    using Domains.Session;
    using Domains.Room;
    using Domains.User;

    public sealed class Session : Domains.Session.Session, ISession
    {
        public Session() {}
        public Session(DayOfWeek day, DateTime time, IRoom room, IUser Instructor, SessionType type)
        {
            this.Day = day;
            this.Time = time;
            this.Room = room;
            this.Instructor = Instructor;
            this.Type = type;
        }

        public override string Id { get; set; }
        public override DayOfWeek Day { get; set; }
        public override DateTime Time { get; set; }
        public override IRoom Room { get; set; }
        public override IUser Instructor { get; set; }
        public override SessionType Type { get; set; }
    }
}
