namespace eWAN.WebApi.UseCases.CreateRoom
{
    using Application.Boundaries.CreateRoom;
    using Microsoft.AspNetCore.Mvc;

    public class CreateRoomPresenter : ICreateRoomOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(CreateRoomOutput output) => 
            this.ViewModel = new CreatedAtRouteResult("Room", new CreateRoomResponse(output.newRoom.Id));

        public void WriteError(string message) => this.ViewModel = new UnprocessableEntityObjectResult(new { message });
    }
}
