using Application.Features.VehicleBrands.Querys.GetByList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Querys.GetByList
{
    public class Get_Airport_ListQuery : IRequest<List<Get_Airport_ListVM>>
    {
    }
}
