using eWAN.Domains.User;

namespace eWAN.Domains.Student
{
    public interface IStudentFactory
    {
        IStudent NewStudent(IUser details);
    }
}
