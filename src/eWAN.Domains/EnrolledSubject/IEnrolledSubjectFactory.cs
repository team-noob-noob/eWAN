namespace eWAN.Domains.EnrolledSubject
{
    using User;
    using Subject;
    using Student;

    public interface IEnrolledSubjectFactory
    {
        IEnrolledSubject NewEnrolledSubject(
            IStudent student,
            ISubject subject,
            string grade = null
        );
    }
}
