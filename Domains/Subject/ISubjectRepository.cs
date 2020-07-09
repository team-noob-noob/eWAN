using System.Threading.Tasks;

namespace eWAN.Domains.Subject
{
    public interface ISubjectRepository
    {
        Task Add(ISubject subject);
    }
}
