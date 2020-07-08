namespace eWAN.Domains.EnrolledProgram
{
    using User;
    using Program;

    public interface IEnrolledProgram : IBaseEntity
    {
        int Id { get; set; }
        IUser Student { get; set; }
        IProgram Program { get; set; }
    }
}
