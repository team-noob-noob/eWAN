namespace eWAN.WebApi.UseCases.CreateSubject
{
    using Domains.Subject;

    public class CreateSubjectResponse
    {
        public CreateSubjectResponse(ISubject NewSubject)
        {
            this.NewSubject = NewSubject;
        }

        public ISubject NewSubject { get; }
    }
}
