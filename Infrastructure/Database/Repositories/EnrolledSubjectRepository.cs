namespace eWAN.Infrastructure.Database.Repositories
{
    using System.Threading.Tasks;
    using Domains.EnrolledSubject;
    using EnrolledSubject = Entities.EnrolledSubject;

    public class EnrolledSubjectRepository : IEnrolledSubjectRepository
    {
        public EnrolledSubjectRepository(EwanContext context)
        {
            this._context = context;
        }
        private EwanContext _context;

        public async Task AddEnrolledSubject(IEnrolledSubject enrolledSubject)
        {
            await this._context.EnrolledSubjects.AddAsync((EnrolledSubject) enrolledSubject);
            await this._context.SaveChangesAsync();
        }
    }
}
