using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Create
{
    public class Create_VehicleBrands_Commands : IRequest<Create_VehicleBrands_CommandsResponse>
    {
        public string VehicleBrandName { get; set; }
        public int VehicleCompanyId { get; set; }
      
    }
}
