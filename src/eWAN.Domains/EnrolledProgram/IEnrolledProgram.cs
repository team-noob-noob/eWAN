namespace eWAN.Domains.EnrolledProgram
{
    using Program;
    using Student;

    ///<summary>
    /// Represents a <see cref="Student"/> enrollment to a <see cref="Program"/>
    /// </summary>
    public interface IEnrolledProgram : IBaseEntity
    {
        IStudent Student { get; set; }
        IProgram Program { get; set; }
    }
}
