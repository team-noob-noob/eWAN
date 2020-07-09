using System.Threading.Tasks;

namespace eWAN.Domains.Session
{
    public interface ISessionRepository
    {
        Task Add(ISession session);
    }
}
