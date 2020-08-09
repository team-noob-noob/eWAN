using System;

namespace eWAN.Domains.Session
{
    using Room;
    using User;

    public interface ISessionFactory
    {
        ISession AddSession(
            DayOfWeek day,
            TimeSpan startTime,
            TimeSpan endTime,
            IRoom room,
            IUser instructor,
            SessionType type
        );
    }
}
