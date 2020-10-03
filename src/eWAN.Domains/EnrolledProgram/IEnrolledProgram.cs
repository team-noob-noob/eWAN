namespace eWAN.Domains.EnrolledProgram
{
    using User;
    using Program;
    using Student;

    ///<summary>Represents a student's enrollment to a program</summary>
    public interface IEnrolledProgram : IBaseEntity
    {
        int Id { get; set; }
        IStudent Student { get; set; }
        IProgram Program { get; set; }
    }
}
