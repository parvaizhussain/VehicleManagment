
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Booking.Querys.GetByID
{
    public class Get_booking_Query : IRequest<Get_booking_VM>
    {
        public int BookingMID { get; set; }
    }
}
