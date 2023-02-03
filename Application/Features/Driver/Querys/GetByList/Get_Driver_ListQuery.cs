using Application.Features.VehicleBrands.Querys.GetByList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Querys.GetByList
{
    public class Get_Driver_ListQuery : IRequest<List<Get_Driver_ListVM>>
    {
    }
}
