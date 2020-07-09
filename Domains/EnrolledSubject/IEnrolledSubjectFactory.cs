namespace eWAN.Domains.EnrolledSubject
{
    using User;
    using Subject;

    public interface IEnrolledSubjectFactory
    {
        IEnrolledSubject NewEnrolledSubject(
            IUser student,
            ISubject subject,
            string grade = null
        );
    }
}
