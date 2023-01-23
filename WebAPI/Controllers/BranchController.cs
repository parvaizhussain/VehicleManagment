using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Features.Branch.Queries.GetBranchByID;
using Application.Features.Branch.Queries.GetBranchList;
using Application.Features.Branch.Commands.CreateBranch;
using Application.Features.Branch.Commands.UpdateBranch;
using Application.Features.Branch.Commands.DeleteBranch;
using Application.Features.Branch.Queries.GetBranchByShortName;
using Application.Features.Branch.Queries.GetBranchByNetworkID;
using Application.Features.Branch.Queries.GetBranchByRegionID;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
        private readonly IMediator _mediator;
        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetBranchById")]
        public async Task<ActionResult<GetBranchVM>> GetBranchById(int id)
        {
            var getBranchQuery = new GetBranchQuery() { BranchId = id };
            return Ok(await _mediator.Send(getBranchQuery));
        }

        [HttpGet("NetworkId", Name = "GetBranchByNetworkId")]
        public async Task<ActionResult<List<GetBranchVM>>> GetBranchByNetworkId(int id)
        {
            var dtos = await _mediator.Send(new GetNetworkBranchQuery() { NetworkId = id });
            return Ok(dtos);
        }

        [HttpGet("RegionId", Name = "GetBranchByRegionId")]
        public async Task<ActionResult<List<GetBranchVM>>> GetBranchByRegionId(int id)
        {
            var dtos = await _mediator.Send(new GetRegionBranchQuery() { RegionId = id });
            return Ok(dtos);
        }


        [HttpGet("ShortName", Name = "GetBranchByShortName")]
        public async Task<ActionResult<GetBranchVM>> GetBranchByShortName(string ShortName)
        {
            var getBranchQuery = new GetBranchByShortNameQuery() { ShortName = ShortName };
            return Ok(await _mediator.Send(getBranchQuery));
        }

        [HttpGet("all", Name = "GetAllBranch")]
        public async Task<ActionResult<List<GetBranchListVM>>> GetAllBranch()
        {
            var dtos = await _mediator.Send(new GetBranchListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddBranch")]
        public async Task<ActionResult<CreateBranchCommandResponse>> Create([FromBody] CreateBranchCommand createBranchCommand)
        {
            var response = await _mediator.Send(createBranchCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateBranch")]
        public async Task<ActionResult> Put([FromBody] UpdateBranchCommand updateBranchCommand)
        {
            var response = await _mediator.Send(updateBranchCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteBranch", Name = "DeleteBranchById")]
        public async Task<ActionResult<GetBranchVM>> DeleteBranchById([FromBody] DeleteBranchCommand DeleteBranchCommand)
        {
            var response = await _mediator.Send(DeleteBranchCommand);
            return Ok(response);
        }

    }
}
