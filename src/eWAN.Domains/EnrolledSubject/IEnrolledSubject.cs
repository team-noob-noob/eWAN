namespace eWAN.Domains.EnrolledSubject
{
    using User;
    using Subject;
    using Student;

    public interface IEnrolledSubject : IBaseEntity
    {
        int Id { get; set; }
        IStudent enrolledStudent { get; set; }
        ISubject subject { get; set; }
        string grade { get; set; }
    }
}