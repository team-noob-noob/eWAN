using System.Collections.Generic;
using System.Linq;

namespace eWAN.Domains.Session
{
    public class Schedule : List<ISession>, ISchedule
    {
        public bool IsNewSessionFit(ISession newSession)
        {
            var sameDaySessions = this.Where(x => x.Day == newSession.Day).OrderBy(x => x.StartTime);

            if(sameDaySessions.Any())
            {
                return true;
            }

            foreach(var sameDaySession in sameDaySessions)
            {
                if((newSession.StartTime >= sameDaySession.StartTime && newSession.EndTime < sameDaySession.EndTime) ||
                (newSession.EndTime >= sameDaySession.StartTime && newSession.EndTime < sameDaySession.EndTime))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
