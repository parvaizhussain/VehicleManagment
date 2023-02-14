using Application.Features.FuelCard.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelCard.Querys.GetByID
{
    public class Get_FuelCard_Query : IRequest<Get_FuelCard_VM>
    {
        public int CardID { get; set; }
    }
}
