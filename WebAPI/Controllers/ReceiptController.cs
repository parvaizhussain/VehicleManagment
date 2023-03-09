using Application.Features.Receipt.Command.Create;
using Application.Features.Receipt.Command.Delete;
using Application.Features.Receipt.Command.Update;
using Application.Features.Receipt.Querys.GetByID;
using Application.Features.Receipt.Querys.GetByList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReceiptController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetReceiptById")]
        public async Task<ActionResult<Get_Receipt_VM>> GetReceiptById(int id)
        {
            var getReceiptQuery = new Get_Receipt_Query() { ReceiptId = id };
            return Ok(await _mediator.Send(getReceiptQuery));
        }


        [HttpGet("all", Name = "GetAllReceipt")]
        public async Task<ActionResult<List<Get_Receipt_ListVM>>> GetAllReceipt()
        {
            var dtos = await _mediator.Send(new Get_Receipt_ListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddReceipt")]
        public async Task<ActionResult<Create_Receipt_CommandsResponse>> Create([FromBody] Create_Receipt_Commands createReceiptCommand)
        {
            var response = await _mediator.Send(createReceiptCommand);
            return Ok(response);
        }

        [HttpPatch(Name = "UpdateReceipt")]
        public async Task<ActionResult> Put([FromBody] Update_Receipt_Commads updateReceiptCommand)
        {
            var response = await _mediator.Send(updateReceiptCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteReceipt", Name = "DeleteReceiptById")]
        public async Task<ActionResult<Get_Receipt_VM>> DeleteReceiptById([FromBody] Delete_Receipt_Commands DeleteReceiptCommand)
        {
            var response = await _mediator.Send(DeleteReceiptCommand);
            return Ok(response);
        }

    }
}
