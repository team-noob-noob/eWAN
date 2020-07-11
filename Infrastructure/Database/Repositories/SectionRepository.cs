using System.Threading.Tasks;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Section;
    using Section = Entities.Section;

    public class SectionRepository : ISectionRepository
    {
        public SectionRepository(EwanContext context) => this._context = context;
        private EwanContext _context;

        public async Task Add(ISection section)
        {
            this._context.Sections.Add((Section) section);
            await this._context.SaveChangesAsync();
        }
    }
}
