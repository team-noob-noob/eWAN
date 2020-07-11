using System;
using System.Threading.Tasks;

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
            course.deletedAt = DateTime.Now;
            await this._context.SaveChangesAsync();
        }
    }
}
