using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace eWAN.Infrastructure.Database.Repositories
{
    using Domains.Session;
    using eWAN.Domains.Room;
    using eWAN.Domains.Semester;
    using eWAN.Domains.User;
    using Session = Entities.Session;

    public class SessionRepository : ISessionRepository
    {
        public SessionRepository(EwanContext context) => this._context = context;
        private EwanContext _context;

        public async Task Add(ISession session)
        {
            this._context.Add((Session) session);
            await this._context.SaveChangesAsync();
        }

        public async Task<List<ISession>> GetSessionsByRoomAndSemester(IRoom room, ISemester semester)
        {
            var sessions = semester.OpenCourses
                .SelectMany(x => x.Sessions)
                .Where(y => y.Room.Id == room.Id);
            return await Task.FromResult(sessions.ToList());
        }

        public async Task<List<ISession>> GetSessionsByInstructorAndSemester(IUser instructor, ISemester semester)
        {
            var sessions = semester.OpenCourses
                .SelectMany(x => x.Sessions)
                .Where(y => y.Instructor.Id == instructor.Id);
            return await Task.FromResult(sessions.ToList());
        }

        public async Task<List<ISession>> GetSessionsByStudentAndSemester(IUser student, ISemester semester)
        {
            var sessions = semester.OpenCourses
                .Where(x => x.Students.Where(y => y.enrolledStudent.Id == student.Id).Count() >= 1)
                .SelectMany(x => x.Sessions);
            return await Task.FromResult(sessions.ToList());
        }
    }
}
