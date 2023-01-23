using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Querys.GetByList
{
    public class Get_VehicleCompany_ListVM
    {
        public int VehicleCompanyId { get; set; }
        public string VehicleCompanyName { get; set; }
        public bool IsActive { get; set; }
    }
}
