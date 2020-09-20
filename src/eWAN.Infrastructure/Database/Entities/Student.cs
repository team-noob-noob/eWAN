using eWAN.Domains.Student;
using eWAN.Domains.User;

namespace eWAN.Infrastructure.Database.Entities
{
    public class Student : Domains.Student.Student, IStudent
    {
        protected Student() {}
        public Student(IUser details)
        {
            this.User = details;
        }

        public string UserId { get; set; }
    }
}
