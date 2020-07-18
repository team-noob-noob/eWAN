using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace eWAN.Domains.Session
{
    public class SessionFitService : ISessionFitService
    {
        public async Task<bool> IsSessionFitInSched(List<ISession> sessions, ISession newSession)
        {
            var sameDaySessions = sessions
                .Where(x => x.Day == newSession.Day)
                .OrderBy(x => x.StartTime);
            
            if(sameDaySessions.Count() <= 0)
            {
                return await Task.FromResult(true);
            }

            foreach(var sameDaySession in sameDaySessions)
            {
                if((newSession.StartTime >= sameDaySession.StartTime && newSession.EndTime < sameDaySession.EndTime) ||
                (newSession.EndTime >= sameDaySession.StartTime && newSession.EndTime < sameDaySession.EndTime))
                {
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
    }
}
