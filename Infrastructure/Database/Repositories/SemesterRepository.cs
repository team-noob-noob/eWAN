using System.Threading.Tasks;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Semester;
    using Semester = Entities.Semester;

    public class SemesterRepository : ISemesterRepository
    {
        public SemesterRepository(EwanContext context) => this._context = context; 
        private EwanContext _context;

        public async Task Add(ISemester semester)
        {
            this._context.Add((Semester) semester);
            await this._context.SaveChangesAsync();
        }
    }
}
