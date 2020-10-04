using System.Threading.Tasks;
using eWAN.Domains.Course;
using Course = eWAN.Infrastructure.Database.Entities.Course;
using System.Linq;

namespace eWAN.Tests.Fakes
{
    public sealed class CourseRepositoryFake : ICourseRepository
    {
        public CourseRepositoryFake(EwanContextFake context) => _context = context;
        private readonly EwanContextFake _context;

        public async Task Add(ICourse course) 
            => await Task.Run(() => _context.Courses.Add((Course) course));
        

        public async Task<ICourse> GetCourseById(string id)
            => await Task.FromResult(_context.Courses.FirstOrDefault(x => x.Id == id));
        

        public async Task<ICourse> GetCourseByTitle(string title)
            => await Task.FromResult(_context.Courses.FirstOrDefault(x => x.Title == title));

        public async Task Remove(ICourse course)
            => await Task.Run(() => _context.Courses.Remove((Course) course));
    }
}
