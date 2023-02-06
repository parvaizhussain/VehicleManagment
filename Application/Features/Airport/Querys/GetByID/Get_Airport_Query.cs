using Application.Features.VehicleBrands.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Querys.GetByID
{
    public class Get_Airport_Query : IRequest<Get_Airport_VM>
    {
        public int AirportID { get; set; }
  
    }
}
