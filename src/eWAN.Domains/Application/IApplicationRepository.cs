using System.Threading.Tasks;
using System.Collections.Generic;

namespace eWAN.Domains.Application
{
    public interface IApplicationRepository
    {
        Task Add(IApplication newApplication);
        IApplication GetApplicationById(string id);
        List<IApplication> GetApplicationsByApplicantId(int applicantId);
    }
}
