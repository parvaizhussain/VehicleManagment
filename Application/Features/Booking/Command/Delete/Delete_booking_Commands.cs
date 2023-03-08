
using Application.Features.ServiceCenter.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Features.Booking.Querys.GetByID;

namespace Application.Features.Booking.Command.Delete
{
    public class Delete_booking_Commands : IRequest<Get_booking_VM>
    {
        public int BookingMID { get; set; }
    }
}
