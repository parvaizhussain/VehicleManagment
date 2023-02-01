using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Features.AccessRights.Queries.GetAccessRightsByID;
using Application.Features.AccessRights.Queries.GetAccessRightsList;
using Application.Features.AccessRights.Commands.CreateAccessRights;
using Application.Features.AccessRights.Commands.UpdateAccessRights;
using Application.Features.AccessRights.Commands.DeleteAccessRights;
using Application.Features.AccessRights.Queries.GetAccessRightsByShortName;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessRightsController : Controller
    {
        private readonly IMediator _mediator;
        public AccessRightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetAccessRightsById")]
        public async Task<ActionResult<GetAccessRightsVM>> GetAccessRightsById(int id)
        {
            var getAccessRightsQuery = new GetAccessRightsQuery() { AccessRightsId = id };
            return Ok(await _mediator.Send(getAccessRightsQuery));
        }

        [HttpGet("ShortName", Name = "GetAccessRightsByShortName")]
        public async Task<ActionResult<GetAccessRightsVM>> GetAccessRightsByShortName(string ShortName)
        {
            var getAccessRightsQuery = new GetAccessRightsByShortNameQuery() { ShortName = ShortName };
            return Ok(await _mediator.Send(getAccessRightsQuery));
        }

        [HttpGet("all", Name = "GetAllAccessRights")]
        public async Task<ActionResult<List<GetAccessRightsListVM>>> GetAllAccessRights()
        {
            var dtos = await _mediator.Send(new GetAccessRightsListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddAccessRights")]
        public async Task<ActionResult<CreateAccessRightsCommandResponse>> Create([FromBody] CreateAccessRightsCommand createAccessRightsCommand)
        {
            var response = await _mediator.Send(createAccessRightsCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateAccessRights")]
        public async Task<ActionResult> Put([FromBody] UpdateAccessRightsCommand updateAccessRightsCommand)
        {
            var response = await _mediator.Send(updateAccessRightsCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteAccessRights", Name = "DeleteAccessRightsById")]
        public async Task<ActionResult<GetAccessRightsVM>> DeleteAccessRightsById([FromBody] DeleteAccessRightsCommand DeleteAccessRightsCommand)
        {
            var response = await _mediator.Send(DeleteAccessRightsCommand);
            return Ok(response);
        }

    }
}
