using Application.Features.Driver.Command.Create;
using Application.Features.Driver.Command.Delete;
using Application.Features.Driver.Command.Update;
using Application.Features.Driver.Querys.GetByID;
using Application.Features.Driver.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetDriverById")]
        public async Task<ActionResult<Get_Driver_VM>> GetCityById(int id)
        {
            var getCityQuery = new Get_Driver_Query() { DriverID = id };
            return Ok(await _mediator.Send(getCityQuery));
        }


        [HttpGet("all", Name = "GetAllDriver")]
        public async Task<ActionResult<List<Get_Driver_ListVM>>> GetAllCity()
        {
            var dtos = await _mediator.Send(new Get_Driver_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddDriver")]
        public async Task<ActionResult<Create_Driver_CommandsResponse>> Create([FromBody] Create_Driver_Commands createCityCommand)
        {
            var response = await _mediator.Send(createCityCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateDriver")]
        public async Task<ActionResult> Put([FromBody] Update_Driver_Commads updateCityCommand)
        {
            var response = await _mediator.Send(updateCityCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteDriver", Name = "DeleteDriverById")]
        public async Task<ActionResult<Get_Driver_VM>> DeleteCityById([FromBody] Delete_Driver_Commands DeleteCityCommand)
        {
            var response = await _mediator.Send(DeleteCityCommand);
            return Ok(response);
        }
    }
}
