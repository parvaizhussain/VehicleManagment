using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Booking.Command.Create
{
    public class Create_booking_CommandsResponse: BaseResponse
    {
        public Create_booking_CommandsResponse() : base()
        {

        }

        public Create_booking_Dto _Create_booking_Dto { get; set; }
    }
}
