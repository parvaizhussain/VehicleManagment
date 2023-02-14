using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Command.Update
{
    public class Update_VehicleCompany_Commads : IRequest
    {
        public int VehicleCompanyId { get; set; }
        public string VehicleCompanyName { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
