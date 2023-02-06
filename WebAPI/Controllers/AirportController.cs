using Application.Features.Airport.Command.Create;
using Application.Features.Airport.Command.Delete;
using Application.Features.Airport.Command.Update;
using Application.Features.Airport.Querys.GetByID;
using Application.Features.Airport.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AirportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetAirportById")]
        public async Task<ActionResult<Get_Airport_VM>> GetAirportById(int id)
        {
            var getAirportQuery = new Get_Airport_Query() { AirportID = id };
            return Ok(await _mediator.Send(getAirportQuery));
        }


        [HttpGet("all", Name = "GetAllAirport")]
        public async Task<ActionResult<List<Get_Airport_ListVM>>> GetAllAirport()
        {
            var dtos = await _mediator.Send(new Get_Airport_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddAirport")]
        public async Task<ActionResult<Create_Airport_CommandsResponse>> Create([FromBody] Create_Airport_Commands createAirportCommand)
        {
            var response = await _mediator.Send(createAirportCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateAirport")]
        public async Task<ActionResult> Put([FromBody] Update_Airport_Commads updateAirportCommand)
        {
            var response = await _mediator.Send(updateAirportCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteAirport", Name = "DeleteAirportById")]
        public async Task<ActionResult<Get_Airport_VM>> DeleteAirportById([FromBody] Delete_Airport_Commands DeleteAirportCommand)
        {
            var response = await _mediator.Send(DeleteAirportCommand);
            return Ok(response);
        }

    }
}
