using System;
using System.Threading.Tasks;
using System.Linq;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Course;
    using Course = Entities.Course;

    public class CourseRepository : ICourseRepository
    {
        public CourseRepository(EwanContext context) => this._context = context;
        private EwanContext _context;

        public async Task Add(ICourse course)
        {
            this._context.Courses.Add((Course) course);
            await this._context.SaveChangesAsync();
        }

        public async Task Remove(ICourse course)
        {
            course.DeletedAt = DateTime.Now;
            await this._context.SaveChangesAsync();
        }

        public async Task<ICourse> GetCourseById(string Id)
        {
            var course = this._context.Courses.FirstOrDefault(x => x.Id == Id && x.DeletedAt == null);
            if(course is null)
            {
                return null;
            }
            return await Task.FromResult(course);
        }

        public async Task<ICourse> GetCourseByTitle(string title)
        {
            var course = this._context.Courses.FirstOrDefault(x => x.Title == title && x.DeletedAt == null);
            if(course is null)
            {
                return null;
            }
            return await Task.FromResult(course);
        }
    }
}
