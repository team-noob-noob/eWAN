using System;

namespace eWAN.Domains.Session
{
    using Room;
    using User;
    using Subject;

    public interface ISession : IBaseEntity
    {
        string Id { get; set; }
        DayOfWeek Day { get; set; }
        TimeSpan StartTime { get; set; }
        TimeSpan EndTime { get; set; }
        IRoom Room { get; set; }
        IUser Instructor { get; set; }
        SessionType Type { get; set; }

        // Inverse Property
        ISubject Subject { get; set; }
    }
}
