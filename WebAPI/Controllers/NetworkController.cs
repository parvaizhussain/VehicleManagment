using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Features.Network.Queries.GetNetworkByID;
using Application.Features.Network.Queries.GetNetworkList;
using Application.Features.Network.Commands.CreateNetwork;
using Application.Features.Network.Commands.UpdateNetwork;
using Application.Features.Network.Commands.DeleteNetwork;
using Application.Features.Network.Queries.GetNetworkByShortName;
using Application.Features.Network.Queries.GetNetworkByCityID;
using Application.Features.Network.Queries.GetNetworkByRegionCode;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkController : Controller
    {
        private readonly IMediator _mediator;
        public NetworkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetNetworkById")]
        public async Task<ActionResult<GetNetworkVM>> GetNetworkById(int id)
        {
            var getNetworkQuery = new GetNetworkQuery() { NetworkId = id };
            return Ok(await _mediator.Send(getNetworkQuery));
        }

        [HttpGet("CityId", Name = "GetGroupByCityId")]
        public async Task<ActionResult<List<GetNetworkVM>>> GetGroupByCityId(int id)
        {
            var getCityQuery = new GetCityNetworkQuery() { CityId = id };
            return Ok(await _mediator.Send(getCityQuery));
        }
        [HttpGet("RegionCode", Name = "GetGroupByRegionCode")]
        public async Task<ActionResult<List<GetNetworkByRegionCodeVM>>> GetGroupByRegionCode(string id)
        {
            var getCityQuery = new GetNetworkByRegionCodeQuery() { RegionCode = id };
            return Ok(await _mediator.Send(getCityQuery));
        }

        [HttpGet("ShortName", Name = "GetNetworkByShortName")]
        public async Task<ActionResult<GetNetworkVM>> GetNetworkByShortName(string ShortName)
        {
            var getNetworkQuery = new GetNetworkByShortNameQuery() { ShortName = ShortName };
            return Ok(await _mediator.Send(getNetworkQuery));
        }

        [HttpGet("all", Name = "GetAllNetwork")]
        public async Task<ActionResult<List<GetNetworkListVM>>> GetAllNetwork()
        {
            var dtos = await _mediator.Send(new GetNetworkListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddNetwork")]
        public async Task<ActionResult<CreateNetworkCommandResponse>> Create([FromBody] CreateNetworkCommand createNetworkCommand)
        {
            var response = await _mediator.Send(createNetworkCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateNetwork")]
        public async Task<ActionResult> Put([FromBody] UpdateNetworkCommand updateNetworkCommand)
        {
            var response = await _mediator.Send(updateNetworkCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteNetwork", Name = "DeleteNetworkById")]
        public async Task<ActionResult<GetNetworkVM>> DeleteNetworkById([FromBody] DeleteNetworkCommand DeleteNetworkCommand)
        {
            var response = await _mediator.Send(DeleteNetworkCommand);
            return Ok(response);
        }

    }
}
