using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Application;
    using Application = Entities.Application;

    public class ApplicationRepository : IApplicationRepository
    {
        public ApplicationRepository(EwanContext context) => this._context = context ?? throw new ArgumentNullException(nameof(context));

        private readonly EwanContext _context;

        public async Task Add(IApplication newApplication)
        {
            await this._context.Applications.AddAsync((Application) newApplication);
            await this._context.SaveChangesAsync();
        }

        public IApplication GetApplicationById(string id)
        {
            return (IApplication) this._context.Applications.Where(x => x.Id == id);
        }

        public List<IApplication> GetApplicationsByApplicantId(string applicantId)
        {
            List<IApplication> result = new List<IApplication>();
            var query = this._context.Applications.Where(x => x.applicant.Id == applicantId).ToList();
            foreach(IApplication application in query)
                result.Add(application);
            return result;
        }
    }
}
