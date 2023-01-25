
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Querys.GetByID
{
    public class Get_VehicleDetails_Query : IRequest<Get_VehicleDetails_VM>
    {
        public int VehicleID { get; set; }
      
    }
}
