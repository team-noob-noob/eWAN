using System.Threading.Tasks;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Program;
    using Program = Entities.Program;

    public class ProgramRepository : IProgramRepository
    {
        public ProgramRepository(EwanContext context) => this._context = context;
        private EwanContext _context;

        public async Task Add(IProgram program)
        {
            this._context.Programs.Add((Program) program);
            await this._context.SaveChangesAsync();
        }
    }
}
