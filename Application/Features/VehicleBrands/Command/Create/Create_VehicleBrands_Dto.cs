using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Create
{
    public class Create_VehicleBrands_Dto
    {
        public int VehicleBrandId { get; set; }
        public string VehicleBrandName { get; set; }
        public int VehicleCompanyId { get; set; }
        public Domain.Entities.VehicleCompany VehicleCompany { get; set; }
    }
}
