using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace eWAN.Tests.Fakes
{
    using Domains.Application;
    using Application = Infrastructure.Database.Entities.Application;

    public class ApplicationRepositoryFake : IApplicationRepository
    {
        public ApplicationRepositoryFake(EwanContextFake context) => this._context = context;
        private EwanContextFake _context;

        public async Task Add(IApplication newApplication)
        {
            this._context.Applications.Add((Application) newApplication);
            await Task.CompletedTask;
        }

        public IApplication GetApplicationById(string id) => 
            this._context.Applications.SingleOrDefault(e => e.Id == id);
        
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
