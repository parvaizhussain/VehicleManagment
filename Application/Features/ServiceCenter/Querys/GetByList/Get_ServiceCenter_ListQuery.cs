using Application.Features.VehicleBrands.Querys.GetByList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Querys.GetByList
{
    public class Get_ServiceCenter_ListQuery : IRequest<List<Get_ServiceCenter_ListVM>>
    {
    }
}
