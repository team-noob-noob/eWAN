using Microsoft.AspNetCore.Mvc;

namespace eWAN.WebApi.UseCases.ApplicationJurying
{
    using Application.Boundaries.ApplicationJurying;

    public class ApplicationJuryingPresenter : IApplicationJuryingOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(ApplicationJuryingOutput output) => this.ViewModel = new OkResult();

        public void WriteError(string message) => this.ViewModel = new BadRequestObjectResult(new { message });
    }
}
