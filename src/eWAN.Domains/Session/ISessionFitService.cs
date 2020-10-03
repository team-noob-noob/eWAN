using System.Threading.Tasks;
using System.Collections.Generic;

namespace eWAN.Domains.Session
{
    public interface ISessionFitService
    {
        Task<bool> IsSessionFitInSchedule(List<ISession> sessions, ISession newSession);
    }
}
