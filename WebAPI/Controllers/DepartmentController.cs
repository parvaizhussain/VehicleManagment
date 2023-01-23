using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Features.Department.Queries.GetDepartmentByID;
using Application.Features.Department.Queries.GetDepartmentList;
using Application.Features.Department.Commands.CreateDepartment;
using Application.Features.Department.Commands.UpdateDepartment;
using Application.Features.Department.Queries.GetDepartmentByShortName;
using Application.Features.Department.Commands.DeleteDepartment;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetDepartmentById")]
        public async Task<ActionResult<GetDepartmentVM>> GetDepartmentById(int id)
        {
            var getDepartmentQuery = new GetDepartmentQuery() { DepartmentId = id };
            return Ok(await _mediator.Send(getDepartmentQuery));
        }

        [HttpGet("ShortName", Name = "GetDepartmentByShortName")]
        public async Task<ActionResult<GetDepartmentVM>> GetDepartmentByShortName(string ShortName)
        {
            var getDepartmentQuery = new GetDepartmentByShortNameQuery() { ShortName = ShortName };
            return Ok(await _mediator.Send(getDepartmentQuery));
        }

        [HttpGet("all", Name = "GetAllDepartment")]
        public async Task<ActionResult<List<GetDepartmentListVM>>> GetAllDepartment()
        {
            var dtos = await _mediator.Send(new GetDepartmentListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddDepartment")]
        public async Task<ActionResult<CreateDepartmentCommandResponse>> Create([FromBody] CreateDepartmentCommand createDepartmentCommand)
        {
            var response = await _mediator.Send(createDepartmentCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateDepartment")]
        public async Task<ActionResult> Put([FromBody] UpdateDepartmentCommand updateDepartmentCommand)
        {
            var response = await _mediator.Send(updateDepartmentCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteDepartment", Name = "DeleteDepartmentById")]
        public async Task<ActionResult<GetDepartmentVM>> DeleteDepartmentById([FromBody] DeleteDepartmentCommand DeleteDepartmentCommand)
        {
            var response = await _mediator.Send(DeleteDepartmentCommand);
            return Ok(response);
        }

    }
}
