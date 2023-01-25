using Application.Features.City.Commands.CreateCity;
//using Application.Features.Vehicle.Command.CreateCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        //private readonly IMediator _mediator;
        //public VehicleController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}
        //[HttpPost(Name = "AddVehicle")]
        //public async Task<ActionResult<CreateVehicleCommand>> Create([FromBody] CreateVehicleCommand createVehicleCommand)
        //{
        //    var response = await _mediator.Send(createVehicleCommand);
        //    return Ok(response);
        //}


    }
}
