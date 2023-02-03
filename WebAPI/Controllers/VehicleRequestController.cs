using Application.Features.City.Commands.CreateCity;
using Application.Features.VehicleRequest.Command.Create;
using Application.Features.VehicleRequest.Command.Delete;
using Application.Features.VehicleRequest.Command.Update;
using Application.Features.VehicleRequest.Querys.GetByID;
using Application.Features.VehicleRequest.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleRequestController : Controller
    {
        private readonly IMediator _mediator;
        public VehicleRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetVRById")]
        public async Task<ActionResult<Get_VehicleRequest_VM>> GetCityById(int id)
        {
            var getCityQuery = new Get_VehicleRequest_Query() { RequestID = id };
            return Ok(await _mediator.Send(getCityQuery));
        }


        [HttpGet("all", Name = "GetAllVR")]
        public async Task<ActionResult<List<Get_VehicleRequest_ListVM>>> GetAllCity()
        {
            var dtos = await _mediator.Send(new Get_VehicleRequest_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddVR")]
        public async Task<ActionResult<Create_VehicleRequest_CommandsResponse>> Create([FromBody] Create_VehicleRequest_Commands createCityCommand)
        {
            var response = await _mediator.Send(createCityCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateVR")]
        public async Task<ActionResult> Put([FromBody] Update_VehicleRequest_Commads updateCityCommand)
        {
            var response = await _mediator.Send(updateCityCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteVR", Name = "DeleteVRById")]
        public async Task<ActionResult<Get_VehicleRequest_VM>> DeleteCityById([FromBody] Delete_VehicleRequest_Commands DeleteCityCommand)
        {
            var response = await _mediator.Send(DeleteCityCommand);
            return Ok(response);
        }
    }
}
