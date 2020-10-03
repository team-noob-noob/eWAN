namespace eWAN.Domains.EnrolledSubject
{
    using Subject;
    using Student;

    ///<summary>Represents a student's enrolled to a subject</summary>
    public interface IEnrolledSubject : IBaseEntity
    {
        int Id { get; set; }
        IStudent EnrolledStudent { get; set; }
        ISubject Subject { get; set; }
        string Grade { get; set; }
    }
}