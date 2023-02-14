using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelCard.Querys.GetByList
{
    public class Get_FuelCard_ListQuery : IRequest<List<Get_FuelCard_ListVM>>
    {
    }
}
