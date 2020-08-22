using System.Threading.Tasks;
using System.Linq;

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

        public async Task<ISemester> GetSemesterById(string Id)
        {
            var semester = this._context.Semesters.SingleOrDefault(x => x.Id == Id && x.deletedAt == null);
            if(semester is null)
            {
                return null;
            }
            return await Task.FromResult(semester);
        }
    }
}
