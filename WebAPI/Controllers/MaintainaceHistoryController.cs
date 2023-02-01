using Application.Features.MaintainaceHistory.Command.Create;
using Application.Features.MaintainaceHistory.Command.Delete;
using Application.Features.MaintainaceHistory.Command.Update;
using Application.Features.MaintainaceHistory.Querys.GetByID;
using Application.Features.MaintainaceHistory.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintainaceHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MaintainaceHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetMaintainaceHistoryById")]
        public async Task<ActionResult<Get_MaintainaceHistory_VM>> GetCityById(int id)
        {
            var getCityQuery = new Get_MaintainaceHistory_Query() { MaintainaceHistoryId = id };
            return Ok(await _mediator.Send(getCityQuery));
        }


        [HttpGet("all", Name = "GetAllMaintainaceHistory")]
        public async Task<ActionResult<List<Get_MaintainaceHistory_ListVM>>> GetAllCity()
        {
            var dtos = await _mediator.Send(new Get_MaintainaceHistory_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddMaintainaceHistory")]
        public async Task<ActionResult<Create_MaintainaceHistory_CommandsResponse>> Create([FromBody] Create_MaintainaceHistory_Commands createCityCommand)
        {
            var response = await _mediator.Send(createCityCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateMaintainaceHistory")]
        public async Task<ActionResult> Put([FromBody] Update_MaintainaceHistory_Commads updateCityCommand)
        {
            var response = await _mediator.Send(updateCityCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteMaintainaceHistory", Name = "DeleteMaintainaceHistoryById")]
        public async Task<ActionResult<Get_MaintainaceHistory_VM>> DeleteCityById([FromBody] Delete_MaintainaceHistory_Commands DeleteCityCommand)
        {
            var response = await _mediator.Send(DeleteCityCommand);
            return Ok(response);
        }
    }
}
