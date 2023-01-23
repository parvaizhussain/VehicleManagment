using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Features.Region.Queries.GetRegionByID;
using Application.Features.Region.Queries.GetRegionList;
using Application.Features.Region.Commands.CreateRegion;
using Application.Features.Region.Commands.UpdateRegion;
using Application.Features.Region.Commands.DeleteRegion;
using Application.Features.Region.Queries.GetRegionByShortName;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly IMediator _mediator;
        public RegionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetRegionById")]
        public async Task<ActionResult<GetRegionVM>> GetRegionById(int id)
        {
            var getRegionQuery = new GetRegionQuery() { RegionId = id };
            return Ok(await _mediator.Send(getRegionQuery));
        }

        [HttpGet("ShortName", Name = "GetRegionByShortName")]
        public async Task<ActionResult<GetRegionVM>> GetRegionByShortName(string ShortName)
        {
            var getRegionQuery = new GetRegionByShortNameQuery() { ShortName = ShortName };
            return Ok(await _mediator.Send(getRegionQuery));
        }

        [HttpGet("all", Name = "GetAllRegion")]
        public async Task<ActionResult<List<GetRegionListVM>>> GetAllRegion()
        {
            var dtos = await _mediator.Send(new GetRegionListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddRegion")]
        public async Task<ActionResult<CreateRegionCommandResponse>> Create([FromBody] CreateRegionCommand createRegionCommand)
        {
            var response = await _mediator.Send(createRegionCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateRegion")]
        public async Task<ActionResult> Put([FromBody] UpdateRegionCommand updateRegionCommand)
        {
            var response = await _mediator.Send(updateRegionCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteRegion", Name = "DeleteRegionById")]
        public async Task<ActionResult<GetRegionVM>> DeleteRegionById([FromBody] DeleteRegionCommand DeleteRegionCommand)
        {
            var response = await _mediator.Send(DeleteRegionCommand);
            return Ok(response);
        }
    }
}
