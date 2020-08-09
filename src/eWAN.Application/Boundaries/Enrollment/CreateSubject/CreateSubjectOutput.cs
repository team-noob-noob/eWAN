namespace eWAN.Application.Boundaries.CreateSubject
{
    using Domains.Subject;

    public class CreateSubjectOutput
    {
        public CreateSubjectOutput(ISubject subject)
        {
            this.Subject = subject;
        }

        public ISubject Subject { get; }
    }
}
