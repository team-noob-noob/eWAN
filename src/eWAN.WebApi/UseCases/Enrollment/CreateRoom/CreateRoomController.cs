using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eWAN.Application.Boundaries.CreateRoom;
using Microsoft.AspNetCore.Http;

namespace eWAN.WebApi.UseCases.CreateRoom
{
    [Route("/api/[controller]/[action]")]
    public class RoomController : Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateRoomResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRoom(
            [FromForm] CreateRoomRequest request,
            [FromServices] CreateRoomPresenter presenter,
            [FromServices] ICreateRoomUseCase useCase
        )
        {
            var input = new CreateRoomInput();

            await useCase.Handle(input);

            return presenter.ViewModel;
        }
    }
}
