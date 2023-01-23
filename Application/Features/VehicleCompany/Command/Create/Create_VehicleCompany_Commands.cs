using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Command.Create
{
    public class Create_VehicleCompany_Commands : IRequest<Create_VehicleCompany_CommandsResponse>
    {
        public string VehicleCompanyName { get; set; }
      
    }
}
