namespace eWAN.Application.Boundaries.StudentApplication
{
    using Domains.User;

    public class StudentApplicationInput
    {
        public StudentApplicationInput(IUser applicant)
        {
            Applicant = applicant;
        }

        public IUser Applicant { get; }
    }
}
