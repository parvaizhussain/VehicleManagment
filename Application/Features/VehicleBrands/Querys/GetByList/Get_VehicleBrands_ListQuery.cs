using Application.Features.VehicleCompany.Querys.GetByList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Querys.GetByList
{
    public class Get_VehicleBrands_ListQuery : IRequest<List<Get_VehicleBrands_ListVM>>
    { 
    }
}
