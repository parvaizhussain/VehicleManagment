
using Application.Features.ServiceCenter.Command.Create;
using Application.Features.ServiceCenter.Command.Delete;
using Application.Features.ServiceCenter.Command.Update;
using Application.Features.ServiceCenter.Querys.GetByID;
using Application.Features.ServiceCenter.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCenterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceCenterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetServiceCenterById")]
        public async Task<ActionResult<Get_ServiceCenter_VM>> GetCityById(int id)
        {
            var getCityQuery = new Get_ServiceCenter_Query() { ServiceCenterId = id };
            return Ok(await _mediator.Send(getCityQuery));
        }


        [HttpGet("all", Name = "GetAllServiceCenter")]
        public async Task<ActionResult<List<Get_ServiceCenter_ListVM>>> GetAllCity()
        {
            var dtos = await _mediator.Send(new Get_ServiceCenter_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddServiceCenter")]
        public async Task<ActionResult<Create_ServiceCenter_CommandsResponse>> Create([FromBody] Create_ServiceCenter_Commands createCityCommand)
        {
            var response = await _mediator.Send(createCityCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateServiceCenter")]
        public async Task<ActionResult> Put([FromBody] Update_ServiceCenter_Commads updateCityCommand)
        {
            var response = await _mediator.Send(updateCityCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteServiceCenter", Name = "DeleteServiceCenterById")]
        public async Task<ActionResult<Get_ServiceCenter_VM>> DeleteCityById([FromBody] Delete_ServiceCenter_Commands DeleteCityCommand)
        {
            var response = await _mediator.Send(DeleteCityCommand);
            return Ok(response);
        }
    }
}
