using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.ApplicationJurying
{
    using Application.Boundaries.ApplicationJurying;

    public class ApplicationJuryingPresenter : IApplicationJuryingOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(ApplicationJuryingOutput output) => ViewModel = new OkResult();

        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(new { message });
    }
}
