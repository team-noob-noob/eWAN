using eWAN.Domains.Subject;
using eWAN.Domains.Student;
using eWAN.Domains.EnrolledSubject;

namespace eWAN.Infrastructure.Database.Entities
{
    public class EnrolledSubject : Domains.EnrolledSubject.EnrolledSubject, IEnrolledSubject
    {
        public EnrolledSubject() {}
        public EnrolledSubject(IStudent student, ISubject subject, string grade = null)
        {
            this.EnrolledStudent = student;
            this.Subject = subject;
            this.Grade = grade;
        }

        public override string Grade { get; set; }
        public int Subject_Id { get; set; }
        public int User_Id { get; set; }
    }
}
