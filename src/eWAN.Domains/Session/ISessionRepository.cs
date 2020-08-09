using System.Threading.Tasks;
using System.Collections.Generic;

namespace eWAN.Domains.Session
{
    using Room;
    using User;
    using Semester;

    public interface ISessionRepository
    {
        Task Add(ISession session);
        Task<List<ISession>> GetSessionsByRoomAndSemester(IRoom room, ISemester semester);
        Task<List<ISession>> GetSessionsByInstructorAndSemester(IUser instructor, ISemester semester);
        Task<List<ISession>> GetSessionsByStudentAndSemester(IUser student, ISemester semester);
    }
}
