
using Application.Features.Airport.Querys.GetByID;
using Application.Features.ServiceCenter.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Command.Delete
{
    public class Delete_Airport_Commands : IRequest<Get_Airport_VM>
    {

        public int AirportID { get; set; }
    }
}
