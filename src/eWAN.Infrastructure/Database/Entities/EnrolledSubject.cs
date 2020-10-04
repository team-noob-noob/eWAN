namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.EnrolledSubject;
    using eWAN.Domains.Subject;
    using eWAN.Domains.Student;

    public class EnrolledSubject : Domains.EnrolledSubject.EnrolledSubject, IEnrolledSubject
    {
        public EnrolledSubject() {}
        public EnrolledSubject(IStudent student, ISubject subject, string grade = null)
        {
            this.EnrolledStudent = student;
            this.Subject = subject;
            this.Grade = grade;
        }

        public override int Id { get; set; }
        public override string Grade { get; set; }
        public string Subject_Id { get; set; }
        public string User_Id { get; set; }
    }
}
