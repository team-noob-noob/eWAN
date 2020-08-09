using System.Threading.Tasks;

namespace eWAN.Domains.EnrolledSubject
{
    public interface IEnrolledSubjectRepository
    {
        Task AddEnrolledSubject(IEnrolledSubject enrolledSubject);
    }
}
