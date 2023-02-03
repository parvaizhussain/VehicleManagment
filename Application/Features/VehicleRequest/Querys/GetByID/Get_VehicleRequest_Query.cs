
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Querys.GetByID
{
    public class Get_VehicleRequest_Query : IRequest<Get_VehicleRequest_VM>
    {
        public int RequestID { get; set; }
       
    }
}
