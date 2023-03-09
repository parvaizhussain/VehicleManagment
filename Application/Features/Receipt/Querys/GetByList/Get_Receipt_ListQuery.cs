using Application.Features.VehicleBrands.Querys.GetByList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Querys.GetByList
{
    public class Get_Receipt_ListQuery : IRequest<List<Get_Receipt_ListVM>>
    {
    }
}
