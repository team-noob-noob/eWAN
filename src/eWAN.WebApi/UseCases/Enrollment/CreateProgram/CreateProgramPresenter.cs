namespace eWAN.WebApi.UseCases.CreateProgram
{
    using Application.Boundaries.CreateProgram;
    using Microsoft.AspNetCore.Mvc;

    public class CreateProgramPresenter : ICreateProgramOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(CreateProgramOutput output) => ViewModel = new CreatedResult("Program", new CreateProgramResponse(output.Program.Id.ToString()));
        public void WriteError(string message) => ViewModel = new UnprocessableEntityObjectResult(new {message});
    }
}
