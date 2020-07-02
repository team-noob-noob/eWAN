using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.StudentApplication
{
    using Application.Boundaries.StudentApplication;
    

    public class StudentApplicationPresenter : IStudentApplicationOutputPort
    {
        public IActionResult Viewmodel = new NoContentResult();

        public void Standard(StudentApplicationOutput output) => 
            this.Viewmodel = new OkObjectResult(new StudentApplicationResponse(output.ConfirmationId));

        public void WriteError(string message) => this.Viewmodel = new BadRequestObjectResult(message);
        
    }
}
