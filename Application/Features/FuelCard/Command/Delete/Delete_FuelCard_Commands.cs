
using Application.Features.FuelCard.Querys.GetByID;
using Application.Features.ServiceCenter.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelCard.Command.Delete
{
    public class Delete_FuelCard_Commands : IRequest<Get_FuelCard_VM>
    {
        public int CardID { get; set; }
    }
}
