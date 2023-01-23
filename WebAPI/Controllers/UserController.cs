using Application.Features.User.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all", Name = "GetAllUser")]
        public async Task<ActionResult<List<GetUserListVM>>> GetAllSubject()
        {
            var dtos = await _mediator.Send(new GetUserListQuery());
            return Ok(dtos);
        }
    }
}
