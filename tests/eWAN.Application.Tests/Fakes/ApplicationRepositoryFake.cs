using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace eWAN.Tests.Fakes
{
    using Domains.Application;
    using Application = Infrastructure.Database.Entities.Application;

    public class ApplicationRepositoryFake : IApplicationRepository
    {
        public ApplicationRepositoryFake(EwanContextFake context) => _context = context;
        private readonly EwanContextFake _context;

        public async Task Add(IApplication newApplication)
        {
            _context.Applications.Add((Application) newApplication);
            await Task.CompletedTask;
        }

        public IApplication GetApplicationById(string id) => 
            _context.Applications.SingleOrDefault(e => e.PublicId == id);
        
        public List<IApplication> GetApplicationsByApplicantId(int applicantId)
        {
            List<IApplication> result = new List<IApplication>();
            var query = _context.Applications.Where(x => x.Applicant.Id == applicantId).ToList();
            foreach(IApplication application in query)
                result.Add(application);
            return result;
        }
    }
}
