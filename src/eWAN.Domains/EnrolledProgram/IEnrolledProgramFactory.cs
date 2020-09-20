namespace eWAN.Domains.EnrolledProgram
{
    using User;
    using Program;
    using Student;

    public interface IEnrolledProgramFactory
    {
        IEnrolledProgram NewEnrolledProgram(
            IStudent student,
            IProgram program
        );
    }
}
