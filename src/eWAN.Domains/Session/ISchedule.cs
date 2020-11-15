using System.Collections;

namespace eWAN.Domains.Session
{
    public interface ISchedule : IList
    {
        public bool IsNewSessionFit(ISession newSession);
    }
}