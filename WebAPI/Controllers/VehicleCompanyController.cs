
using Application.Features.VehicleCompany.Command.Create;
using Application.Features.VehicleCompany.Command.Delete;
using Application.Features.VehicleCompany.Command.Update;
using Application.Features.VehicleCompany.Querys.GetByID;
using Application.Features.VehicleCompany.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleCompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VehicleCompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetVCById")]
        public async Task<ActionResult<Get_VehicleCompany_VM>> GetCityById(int id)
        {
            var getCityQuery = new Get_VehicleCompany_Query() { VehicleCompanyId = id };
            return Ok(await _mediator.Send(getCityQuery));
        }


        [HttpGet("all", Name = "GetAllVC")]
        public async Task<ActionResult<List<Get_VehicleCompany_ListVM>>> GetAllCity()
        {
            var dtos = await _mediator.Send(new Get_VehicleCompany_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddVC")]
        public async Task<ActionResult<Create_VehicleCompany_CommandsResponse>> Create([FromBody] Create_VehicleCompany_Commands createCityCommand)
        {
            var response = await _mediator.Send(createCityCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateVC")]
        public async Task<ActionResult> Put([FromBody] Update_VehicleCompany_Commads updateCityCommand)
        {
            var response = await _mediator.Send(updateCityCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteVC", Name = "DeleteVCById")]
        public async Task<ActionResult<Get_VehicleCompany_VM>> DeleteCityById([FromBody] Delete_VehicleCompany_Commands DeleteCityCommand)
        {
            var response = await _mediator.Send(DeleteCityCommand);
            return Ok(response);
        }

    }
}
