using System.Threading.Tasks;
using System.Collections.Generic;
using eWAN.Domains.Semester;
using eWAN.Domains.Room;
using eWAN.Domains.User;
using eWAN.Domains.Student;

namespace eWAN.Domains.Session
{
    public interface ISessionRepository
    {
        Task Add(ISession session);
        Task<List<ISession>> GetSessionsByRoomAndSemester(IRoom room, ISemester semester);
        Task<List<ISession>> GetSessionsByInstructorAndSemester(IUser instructor, ISemester semester);
        Task<List<ISession>> GetSessionsByStudentAndSemester(IStudent student, ISemester semester);
    }
}
