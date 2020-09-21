using System.Threading.Tasks;
using eWAN.Domains.Program;
using Program = eWAN.Infrastructure.Database.Entities.Program;
using System.Linq;

namespace eWAN.Tests.Fakes
{
    public class ProgramRepositoryFake : IProgramRepository
    {
        public ProgramRepositoryFake(EwanContextFake context) => this._context = context;
        private EwanContextFake _context;

        public async Task Add(IProgram program)
            => await Task.Run(() => this._context.Programs.Add((Program) program));

        public async Task<IProgram> GetProgramByCode(string code)
            => await Task.Run(() => this._context.Programs.FirstOrDefault(x => x.Code == code));

        public async Task<IProgram> GetProgramByTitle(string title)
            => await Task.Run(() => this._context.Programs.FirstOrDefault(x => x.Title == title));
    }
}