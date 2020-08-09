namespace eWAN.Application.Boundaries.StudentApplication
{
    using Domains.User;

    public class StudentApplicationInput
    {
        public StudentApplicationInput(IUser applicant)
        {
            this.applicant = applicant;
        }

        public IUser applicant { get; }
    }
}
