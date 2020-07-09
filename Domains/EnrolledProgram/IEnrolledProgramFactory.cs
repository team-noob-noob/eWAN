namespace eWAN.Domains.EnrolledProgram
{
    using User;

    public interface IEnrolledProgramFactory
    {
        IEnrolledProgram NewEnrolledProgram(
            IUser student,
            IEnrolledProgram program
        );
    }
}
