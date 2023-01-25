using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Update
{
    public class Update_VehicleBrands_Commads : IRequest
    {
        public int VehicleBrandId { get; set; }
        public string VehicleBrandName { get; set; }
        public int VehicleCompanyId { get; set; }
       
    }
}
