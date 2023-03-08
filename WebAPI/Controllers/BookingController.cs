
using Application.Features.Booking.Command.Create;
using Application.Features.Booking.Command.Delete;
using Application.Features.Booking.Command.Update;
using Application.Features.Booking.Querys.GetByID;
using Application.Features.Booking.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetbookingById")]
        public async Task<ActionResult<Get_booking_VM>> GetbookingById(int id)
        {
            var getbookingQuery = new Get_booking_Query() { BookingMID = id };
            return Ok(await _mediator.Send(getbookingQuery));
        }


        [HttpGet("all", Name = "GetAllbooking")]
        public async Task<ActionResult<List<Get_booking_ListVM>>> GetAllbooking()
        {
            var dtos = await _mediator.Send(new Get_booking_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "Addbooking")]
        public async Task<ActionResult<Create_booking_CommandsResponse>> Create([FromBody] Create_booking_Commands createbookingCommand)
        {
            var response = await _mediator.Send(createbookingCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "Updatebooking")]
        public async Task<ActionResult> Put([FromBody] Update_booking_Commads updatebookingCommand)
        {
            var response = await _mediator.Send(updatebookingCommand);
            return Ok(response);
        }

        [HttpPatch("Deletebooking", Name = "DeletebookingById")]
        public async Task<ActionResult<Get_booking_VM>> DeletebookingById([FromBody] Delete_booking_Commands DeletebookingCommand)
        {
            var response = await _mediator.Send(DeletebookingCommand);
            return Ok(response);
        }

    }
}
