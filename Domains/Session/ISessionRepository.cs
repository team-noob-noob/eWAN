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
        Task<ICollection<ISession>> GetSessionsByRoomAndSemester(IRoom room, ISemester semester);
        Task<ICollection<ISession>> GetSessionsByInstructorAndSemester(IUser instructor, ISemester semester);
        Task<ICollection<ISession>> GetSessionsByStudentAndSemester(IUser student, ISemester semester);
    }
}
