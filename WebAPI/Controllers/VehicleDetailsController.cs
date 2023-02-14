using Application.Features.VehicleDetails.Command.Create;
using Application.Features.VehicleDetails.Command.Delete;
using Application.Features.VehicleDetails.Command.Update;
using Application.Features.VehicleDetails.Querys.GetByID;
using Application.Features.VehicleDetails.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VehicleDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetVD_ById")]
        public async Task<ActionResult<Get_VehicleDetails_VM>> GetCityById(int id)
        {
            var getCityQuery = new Get_VehicleDetails_Query() { VehicleID = id };
            return Ok(await _mediator.Send(getCityQuery));
        }


        [HttpGet("all", Name = "GetAllVD")]
        public async Task<ActionResult<List<Get_VehicleDetails_ListVM>>> GetAllCity()
        {
            var dtos = await _mediator.Send(new Get_VehicleDetails_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddVD")]
        public async Task<ActionResult<Create_VehicleDetails_CommandsResponse>> Create([FromBody] Create_VehicleDetails_Commands createCityCommand)
        {
            var response = await _mediator.Send(createCityCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateVD")]
        public async Task<ActionResult> Put([FromBody] Update_VehicleDetails_Commads updateCityCommand)
        {
            var response = await _mediator.Send(updateCityCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteVD", Name = "DeleteVD_ById")]
        public async Task<ActionResult<Get_VehicleDetails_VM>> DeleteCityById([FromBody] Delete_VehicleDetails_Commands DeleteCityCommand)
        {
            var response = await _mediator.Send(DeleteCityCommand);
            return Ok(response);
        }
    }
}
