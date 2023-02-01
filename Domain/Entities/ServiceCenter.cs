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
    public class ServiceCenter : AuditableEntity
    {
        [Key]
        public int ServiceCenterId { get; set; }
        public string? ServiceCenterName { get; set; }
        public string? ContactNo { get; set;}
        public string? ContactPersonName { get; set;}
        public bool DealerType { get; set;}
        [ForeignKey("DealerID")]
        public int DealerID { get; set; }
        public VehicleCompany? VehicleCompany { get; set;}
        public int VehicleCompanyID { get; set; }
    }
}
