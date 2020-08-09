namespace eWAN.Infrastructure.Database.Repositories
{
    using System.Threading.Tasks;
    using Domains.EnrolledProgram;
    using EnrolledProgram = Entities.EnrolledProgram;

    public class EnrolledProgramRepository : IEnrolledProgramRepository
    {
        public EnrolledProgramRepository(EwanContext context) => this._context = context;
        private EwanContext _context;

        public async Task Add(IEnrolledProgram enrolledProgram)
        {
            this._context.EnrolledPrograms.Add((EnrolledProgram) enrolledProgram);
            await this._context.SaveChangesAsync();
        }
    }
}
