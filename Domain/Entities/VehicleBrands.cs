using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehicleBrands : AuditableEntity
    {
        [Key]
        public int VehicleBrandId { get; set; }
        public string VehicleBrandName { get; set; }
        [ForeignKey("VehicleCompanyId")]
        public int VehicleCompanyId { get; set; }
        public VehicleCompany VehicleCompany { get; set; }
    }
}
