using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Delete;
using Petfolio.Application.UseCases.GetAll;
using Petfolio.Application.UseCases.GetById;
using Petfolio.Application.UseCases.Pets.Register;
using Petfolio.Application.UseCases.Pets.Update;
using Petfolio.Communication.Reponses;
using Petfolio.Communication.Request;

namespace Petfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterPetJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ReponserErrorJson), StatusCodes.Status400BadRequest)]

        public IActionResult Register([FromBody] RequestPetJson request)
        {
            var response = new RegisterPetUseCase().Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ReponserErrorJson), StatusCodes.Status400BadRequest)]

        public IActionResult Update([FromRoute] int id, [FromBody] RequestPetJson request)
        {
            var UseCase = new UpdatePetUseCase();

            UseCase.Execute(id, request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult GetAll()
        {
            var useCase = new GetAllPetsUseCase();

            var response = useCase.Execute();

            if (response.Pets.Any())
            {
                return Ok(response);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ReponserErrorJson), StatusCodes.Status404NotFound)]

        public IActionResult Get(int id)
        {
            var useCase = new GetPetByIdUseCase();
            var response = useCase.Execute(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ReponserErrorJson), StatusCodes.Status404NotFound)]

        public IActionResult Delete(int id)
        {
            var useCase = new DeletePetByIdUseCase();
            useCase.Execute(id);

            return NoContent();
        }
    }
}