using System.Threading.Tasks;
using System.Linq;

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

        public async Task<IProgram> GetProgramByTitle(string title)
        {
            return await Task.FromResult(this._context.Programs.SingleOrDefault(x => x.Title == title));
        }

        public async Task<IProgram> GetProgramByCode(string code)
        {
            return await Task.FromResult(this._context.Programs.SingleOrDefault(x => x.Code == code));
        }
    }
}
