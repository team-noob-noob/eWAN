using System.Threading.Tasks;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Subject;
    using Subject = Entities.Subject;

    public class SubjectRepository : ISubjectRepository
    {
        public SubjectRepository(EwanContext context) => this._context = context; 
        private EwanContext _context;

        public async Task Add(ISubject subject)
        {
            this._context.Subjects.Add((Subject) subject);
            await this._context.SaveChangesAsync();
        }
    }
}
