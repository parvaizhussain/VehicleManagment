using Application.Features.VehicleBrands.Querys.GetByList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Querys.GetByList
{
    public class Get_VehicleRequest_ListQuery : IRequest<List<Get_VehicleRequest_ListVM>>
    {
    }
}
