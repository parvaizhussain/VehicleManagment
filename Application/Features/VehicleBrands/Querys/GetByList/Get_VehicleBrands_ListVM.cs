using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Querys.GetByList
{
    public class Get_VehicleBrands_ListVM
    {
        public int VehicleBrandId { get; set; }
        public string VehicleBrandName { get; set; }

        public int VehicleCompanyId { get; set; }
        public Domain.Entities.VehicleCompany VehicleCompany { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
