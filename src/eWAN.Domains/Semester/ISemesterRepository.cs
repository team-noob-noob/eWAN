using System.Threading.Tasks;

namespace eWAN.Domains.Semester
{
    public interface ISemesterRepository
    {
        Task Add(ISemester semester);
        Task<ISemester> GetSemesterById(string Id);
    }
}
