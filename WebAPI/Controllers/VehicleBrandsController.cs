using Application.Features.VehicleBrands.Command.Create;
using Application.Features.VehicleBrands.Command.Delete;
using Application.Features.VehicleBrands.Command.Update;
using Application.Features.VehicleBrands.Querys.GetByID;
using Application.Features.VehicleBrands.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleBrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VehicleBrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetVBById")]
        public async Task<ActionResult<Get_VehicleBrands_VM>> GetCityById(int id)
        {
            var getCityQuery = new Get_VehicleBrands_Query() { VehicleBrandId = id };
            return Ok(await _mediator.Send(getCityQuery));
        }


        [HttpGet("all", Name = "GetAllVB")]
        public async Task<ActionResult<List<Get_VehicleBrands_ListVM>>> GetAllCity()
        {
            var dtos = await _mediator.Send(new Get_VehicleBrands_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddVB")]
        public async Task<ActionResult<Create_VehicleBrands_CommandsResponse>> Create([FromBody] Create_VehicleBrands_Commands createCityCommand)
        {
            var response = await _mediator.Send(createCityCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateVB")]
        public async Task<ActionResult> Put([FromBody] Update_VehicleBrands_Commads updateCityCommand)
        {
            var response = await _mediator.Send(updateCityCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteVB", Name = "DeleteVBById")]
        public async Task<ActionResult<Get_VehicleBrands_VM>> DeleteCityById([FromBody] Delete_VehicleBrands_Commands DeleteCityCommand)
        {
            var response = await _mediator.Send(DeleteCityCommand);
            return Ok(response);
        }
    }
}
