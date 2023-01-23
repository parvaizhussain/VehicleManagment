using Application.Features.Session.Commands.CreateSession;
using Application.Features.Session.Commands.DeleteSession;
using Application.Features.Session.Commands.UpdateSession;
using Application.Features.Session.Queries.GetSessionByID;
using Application.Features.Session.Queries.GetSessionByName;
using Application.Features.Session.Queries.GetSessionList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        private readonly IMediator _mediator;
        public SessionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "AddSession")]
        public async Task<ActionResult<CreateSessionCommandResponse>> Create([FromBody] CreateSessionCommand createSessionCommand)
        {
            var response = await _mediator.Send(createSessionCommand);
            return Ok(response);
        }
        [HttpPatch(Name = "UpdateSession")]
        public async Task<ActionResult> Put([FromBody] UpdateSessionCommand updateSessionCommand)
        {
            var response = await _mediator.Send(updateSessionCommand);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetSessionById")]
        public async Task<ActionResult<GetSessionVM>> GetEventById(int id)
        {
            var getChallanQuery = new GetSessionQuery() { SessionID = id };
            return Ok(await _mediator.Send(getChallanQuery));

        }
        [HttpGet("SessionByName", Name = "GetSessionByName")]
        public async Task<ActionResult<GetSessionByNameVM>> GetEmployeeCNIC(string Name)
        {
            var getEmployeeCNIC = new GetSessionByNameQuery() { Name = Name };
            return Ok(await _mediator.Send(getEmployeeCNIC));
        }
        [HttpGet("all", Name = "GetAllSession")]
        public async Task<ActionResult<List<GetSessionListVM>>> GetAllSession()
        {
            var dtos = await _mediator.Send(new GetSessionListQuery());
            return Ok(dtos);
        }

        [HttpPatch("DeleteSession", Name = "DeleteSessionById")]
        public async Task<ActionResult<GetSessionVM>> DeleteSessionById([FromBody] DeleteSessionCommand DeleteSessionCommand)
        {
            var response = await _mediator.Send(DeleteSessionCommand);
            return Ok(response);
        }

    }
}
