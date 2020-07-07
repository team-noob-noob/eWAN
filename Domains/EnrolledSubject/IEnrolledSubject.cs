namespace eWAN.Domains.EnrolledSubject
{
    using User;
    using Subject;

    public interface IEnrolledSubject : IBaseEntity
    {
        int Id { get; set; }
        IUser enrolledStudent { get; set; }
        ISubject subject { get; set; }
        string grade { get; set; }
    }
}