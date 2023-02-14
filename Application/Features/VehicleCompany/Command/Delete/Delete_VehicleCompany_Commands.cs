using Application.Features.VehicleCompany.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Command.Delete
{
    public class Delete_VehicleCompany_Commands : IRequest<Get_VehicleCompany_VM>
    {
        public int VehicleCompanyId { get; set; }
    }
}
