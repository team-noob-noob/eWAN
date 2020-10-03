namespace eWAN.Domains.EnrolledSubject
{
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
