namespace eWAN.WebApi.UseCases.CreateSubject
{
    using Domains.Subject;

    public class CreateSubjectResponse
    {
        public CreateSubjectResponse(ISubject newSubject)
        {
            NewSubject = newSubject;
        }

        public ISubject NewSubject { get; }
    }
}
