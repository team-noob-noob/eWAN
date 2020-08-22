namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.EnrolledSubject;
    using eWAN.Domains.Subject;
    using eWAN.Domains.User;

    public class EnrolledSubject : Domains.EnrolledSubject.EnrolledSubject, IEnrolledSubject
    {
        public EnrolledSubject() {}
        public EnrolledSubject(IUser student, ISubject subject, string grade = null)
        {
            this.enrolledStudent = student;
            this.subject = subject;
            this.grade = grade;
        }

        public override int Id { get; set; }
        public override string grade { get; set; }
        public string Subject_Id { get; set; }
        public string User_Id { get; set; }
    }
}
