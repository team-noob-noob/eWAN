namespace eWAN.Infrastructure.Database.Entities
{
    using Domains.EnrolledSubject;
    using eWAN.Domains.Subject;
    using eWAN.Domains.User;

    public sealed class EnrolledSubject : Domains.EnrolledSubject.EnrolledSubject, IEnrolledSubject
    {
        public EnrolledSubject() {}
        public EnrolledSubject(IUser student, ISubject subject, string grade = null)
        {
            this.enrolledStudent = student;
            this.subject = subject;
            this.grade = grade;
        }

        public override int Id { get; set; }
        public override IUser enrolledStudent { get; set; }
        public override ISubject subject { get; set; }
        public override string grade { get; set; }
    }
}
