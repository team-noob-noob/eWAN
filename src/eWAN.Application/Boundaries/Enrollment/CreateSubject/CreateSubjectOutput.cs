namespace eWAN.Application.Boundaries.CreateSubject
{
    using Domains.Subject;

    public class CreateSubjectOutput
    {
        public CreateSubjectOutput(ISubject subject)
        {
            Subject = subject;
        }

        public ISubject Subject { get; }
    }
}
