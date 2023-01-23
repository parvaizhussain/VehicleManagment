using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehicleCompany : AuditableEntity
    {
        [Key]
        public int VehicleCompanyID { get; set; }
        public string VehicleCompanyName { get; set; }
        
    }
}
