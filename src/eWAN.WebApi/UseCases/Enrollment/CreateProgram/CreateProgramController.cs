using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace eWAN.WebApi.UseCases.CreateProgram
{
    using Application.Boundaries.CreateProgram;

    [Authorize]
    [Route("/api/[controller]/[action]")]
    public class ProgramController : Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateProgramResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProgram(
            [FromServices] CreateProgramPresenter presenter,
            [FromServices] ICreateProgramUseCase useCase,
            [FromForm] CreateProgramRequest request
        )
        {
            var input = new CreateProgramInput(
                request.Title,
                request.Code,
                request.Description
            );
            await useCase.Handle(input);
            return presenter.ViewModel;
        }
    }
}
