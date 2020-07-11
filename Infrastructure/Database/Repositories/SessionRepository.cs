using System.Threading.Tasks;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Session;
    using Session = Entities.Session;

    public class SessionRepository : ISessionRepository
    {
        public SessionRepository(EwanContext context) => this._context = context;
        private EwanContext _context;

        public async Task Add(ISession session)
        {
            this._context.Add((Session) session);
            await this._context.SaveChangesAsync();
        }
    }
}
