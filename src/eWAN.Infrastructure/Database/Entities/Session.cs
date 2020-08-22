namespace eWAN.Infrastructure.Database.Entities
{
    using System;
    using Domains.Session;
    using Domains.Room;
    using Domains.User;
    using eWAN.Domains.Subject;

    public class Session : Domains.Session.Session, ISession
    {
        public Session() {}
        public Session(DayOfWeek day, TimeSpan startTime, TimeSpan endTime, IRoom room, IUser Instructor, SessionType type)
        {
            this.Day = day;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Room = room;
            this.Instructor = Instructor;
            this.Type = type;
            this.Id =  new Random().NewString(10, "0123456789");
        }

        public override string Id { get; set; }
        public override DayOfWeek Day { get; set; }
        
        public override IRoom Room { get; set; }
        public override IUser Instructor { get; set; }
        public override SessionType Type { get; set; }
        public override TimeSpan StartTime { get; set; }
        public override TimeSpan EndTime { get; set; }
        public override ISubject Subject { get; set; }
    }
}