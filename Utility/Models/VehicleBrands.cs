using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class VehicleBrands
    {
        public int VehicleBrandId { get; set; }
        public string VehicleBrandName { get; set; }
   
        public int VehicleCompanyId { get; set; }
        public VehicleCompany? VehicleCompany { get; set; }
        public bool IsActive { get; set; }
    }
}
