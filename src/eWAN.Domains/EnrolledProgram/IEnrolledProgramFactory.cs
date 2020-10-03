namespace eWAN.Domains.EnrolledProgram
{
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
