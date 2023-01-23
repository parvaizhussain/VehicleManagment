using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Features.Group.Queries.GetGroupByID;
using Application.Features.Group.Queries.GetGroupList;
using Application.Features.Group.Commands.CreateGroup;
using Application.Features.Group.Commands.UpdateGroup;
using Application.Features.Group.Commands.DeleteGroup;
using Application.Features.Group.Queries.GetGroupByShortName;
using Application.Features.Group.Queries.GetDepartmentGroupByID;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IMediator _mediator;
        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetGroupById")]
        public async Task<ActionResult<GetGroupVM>> GetGroupById(int id)
        {
            var getGroupQuery = new GetGroupQuery() { GroupId = id };
            return Ok(await _mediator.Send(getGroupQuery));
        }

        [HttpGet("DepartmentId", Name = "GetGroupByDepartmentId")]
        public async Task<ActionResult<List<GetGroupVM>>> GetGroupByDepartmentId(int id)
        {
            var getCityQuery = new GetDepartmentGroupQuery() { DepartmentId = id };
            return Ok(await _mediator.Send(getCityQuery));
        }

        [HttpGet("ShortName", Name = "GetGroupByShortName")]
        public async Task<ActionResult<GetGroupVM>> GetGroupByShortName(string ShortName)
        {
            var getGroupQuery = new GetGroupByShortNameQuery() { ShortName = ShortName };
            return Ok(await _mediator.Send(getGroupQuery));
        }

        [HttpGet("allGroups", Name = "GetAllGroup")]
        public async Task<ActionResult<List<GetGroupListVM>>> GetAllGroup()
        {
            var dtos = await _mediator.Send(new GetGroupListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddGroup")]
        public async Task<ActionResult<CreateGroupCommandResponse>> Create([FromBody] CreateGroupCommand createGroupCommand)
        {
            var response = await _mediator.Send(createGroupCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateGroup")]
        public async Task<ActionResult> Put([FromBody] UpdateGroupCommand updateGroupCommand)
        {
            var response = await _mediator.Send(updateGroupCommand);
            return Ok(response);
        }


        [HttpPatch("DeleteGroup", Name = "DeleteGroupById")]
        public async Task<ActionResult<GetGroupVM>> DeleteGroupById([FromBody] DeleteGroupCommand DeleteGroupCommand)
        {
            var response = await _mediator.Send(DeleteGroupCommand);
            return Ok(response);
        }


    }
}
