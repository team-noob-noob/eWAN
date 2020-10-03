using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.StudentApplication
{
    using Application.Boundaries.StudentApplication;
    

    public class StudentApplicationPresenter : IStudentApplicationOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(StudentApplicationOutput output) => 
            ViewModel = new OkObjectResult(new StudentApplicationResponse(output.ConfirmationId));

        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(new { Message = message });
        
    }
}
