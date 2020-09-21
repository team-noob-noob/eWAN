using System.Threading.Tasks;
using eWAN.Domains.Course;
using Course = eWAN.Infrastructure.Database.Entities.Course;
using System.Linq;

namespace eWAN.Tests.Fakes
{
    public sealed class CourseRepositoryFake : ICourseRepository
    {
        public CourseRepositoryFake(EwanContextFake context) => this._context = context;
        private EwanContextFake _context;

        public async Task Add(ICourse course) 
            => await Task.Run(() => this._context.Courses.Add((Course) course));
        

        public async Task<ICourse> GetCourseById(string Id)
            => await Task.FromResult(this._context.Courses.FirstOrDefault(x => x.Id == Id));
        

        public async Task<ICourse> GetCourseByTitle(string title)
            => await Task.FromResult(this._context.Courses.FirstOrDefault(x => x.Title == title));

        public async Task Remove(ICourse course)
            => await Task.Run(() => this._context.Courses.Remove((Course) course));
    }
}
