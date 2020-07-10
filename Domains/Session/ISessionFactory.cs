using System;

namespace eWAN.Domains.Session
{
    using Room;
    using User;

    public interface ISessionFactory
    {
        ISession AddSession(
            DayOfWeek day,
            DateTime time,
            IRoom room,
            IUser instructor,
            SessionType type
        );
    }
}
