namespace eWAN.Domains.EnrolledSubject
{
    using User;
    using Subject;
    using Student;

    ///<summary>Represents a student's enrolled to a subject</summary>
    public interface IEnrolledSubject : IBaseEntity
    {
        int Id { get; set; }
        IStudent enrolledStudent { get; set; }
        ISubject subject { get; set; }
        string grade { get; set; }
    }
}