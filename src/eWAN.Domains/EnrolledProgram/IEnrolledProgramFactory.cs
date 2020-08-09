namespace eWAN.Domains.EnrolledProgram
{
    using User;
    using Program;

    public interface IEnrolledProgramFactory
    {
        IEnrolledProgram NewEnrolledProgram(
            IUser student,
            IProgram program
        );
    }
}
