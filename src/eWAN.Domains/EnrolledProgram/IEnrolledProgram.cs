namespace eWAN.Domains.EnrolledProgram
{
    using User;
    using Program;
    using Student;

    public interface IEnrolledProgram : IBaseEntity
    {
        int Id { get; set; }
        IStudent Student { get; set; }
        IProgram Program { get; set; }
    }
}
