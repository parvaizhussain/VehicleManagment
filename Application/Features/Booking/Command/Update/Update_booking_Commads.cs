﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Booking.Command.Update
{
    public class Update_booking_Commads : IRequest
    {
        public int BookingMID { get; set; }
        public int VehicleID { get; set; }
        public int DriverID { get; set; }
        public int FuelCardID { get; set; }
        public string Status { get; set; }
        public int CurrentKM { get; set; }
        public int ArrivedKM { get; set; }
        public ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
