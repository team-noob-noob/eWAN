using System.Threading.Tasks;

namespace eWAN.Domains.Course
{
    public interface ICourseRepository
    {
        Task Add(ICourse course);
        Task Remove(ICourse course);
        Task<ICourse> GetCourseById(string id);
        Task<ICourse> GetCourseByTitle(string title);
    }
}
