namespace eWAN.WebApi.UseCases.CreateRoom
{
    using Application.Boundaries.CreateRoom;
    using Microsoft.AspNetCore.Mvc;

    public class CreateRoomPresenter : ICreateRoomOutputPort
    {
        public IActionResult ViewModel = new NoContentResult();

        public void Standard(CreateRoomOutput output) => 
            ViewModel = new CreatedAtRouteResult("Room", new CreateRoomResponse(output.NewRoom.Code));

        public void WriteError(string message) => ViewModel = new UnprocessableEntityObjectResult(new { message });
    }
}
