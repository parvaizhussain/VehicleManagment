
using Application.Features.FuelCard.Command.Create;
using Application.Features.FuelCard.Command.Update;
using Application.Features.FuelCard.Querys.GetByID;
using Application.Features.FuelCard.Querys.GetByList;
using Application.Features.FuelCard.Command.Delete;
using Application.Features.FuelCard.Command.Update;
using Application.Features.FuelCard.Querys.GetByID;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelCardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FuelCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetFuelCardById")]
        public async Task<ActionResult<Get_FuelCard_VM>> GetFuelCardById(int id)
        {
            var getFuelCardQuery = new Get_FuelCard_Query() { CardID = id };
            return Ok(await _mediator.Send(getFuelCardQuery));
        }


        [HttpGet("all", Name = "GetAllFuelCard")]
        public async Task<ActionResult<List<Get_FuelCard_ListVM>>> GetAllFuelCard()
        {
            var dtos = await _mediator.Send(new Get_FuelCard_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddFuelCard")]
        public async Task<ActionResult<Create_FuelCard_CommandsResponse>> Create([FromBody] Create_FuelCard_Commands createFuelCardCommand)
        {
            var response = await _mediator.Send(createFuelCardCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateFuelCard")]
        public async Task<ActionResult> Put([FromBody] Update_FuelCard_Commands updateFuelCardCommand)
        {
            var response = await _mediator.Send(updateFuelCardCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteFuelCard", Name = "DeleteFuelCardById")]
        public async Task<ActionResult<Get_FuelCard_VM>> DeleteFuelCardById([FromBody] Delete_FuelCard_Commands DeleteFuelCardCommand)
        {
            var response = await _mediator.Send(DeleteFuelCardCommand);
            return Ok(response);
        }

    }
}
