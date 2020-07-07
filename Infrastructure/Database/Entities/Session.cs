namespace eWAN.Infrastructure.Database.Entities
{
    using System;
    using Domains.Session;
    using Domains.Room;
    using Domains.User;

    public sealed class Session : Domains.Session.Session, ISession
    {
        public override string Id { get; set; }
        public override DayOfWeek Day { get; set; }
        public override DateTime Time { get; set; }
        public override IRoom Room { get; set; }
        public override IUser Instructor { get; set; }
        public override SessionType Type { get; set; }
    }
}
