using Application.Features.VehicleBrands.Querys.GetByList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Querys.GetByList
{
    public class Get_VehicleDetails_ListQuery : IRequest<List<Get_VehicleDetails_ListVM>>
    {
    }
}
