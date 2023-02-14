using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Querys.GetByID
{
    public class Get_VehicleCompany_VM
    {
        public string VehicleCompanyId { get; set; }
        public string VehicleCompanyName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
