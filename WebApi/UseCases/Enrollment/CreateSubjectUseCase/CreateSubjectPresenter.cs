namespace eWAN.WebApi.UseCases.CreateSubject
{
    using Application.Boundaries.CreateSubject;
    using Microsoft.AspNetCore.Mvc;

    public class CreateSubjectPresenter : ICreateSubjectOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(CreateSubjectOutput output) => this.ViewModel = new CreatedResult("", new CreateSubjectResponse(output.Subject));

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(new {message});
    }
}
