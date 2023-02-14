using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class ServiceCenter
    {
        
        public int ServiceCenterId { get; set; }
        public string? ServiceCenterName { get; set; }
        public string? ContactNo { get; set; }
        public string? ContactPersonName { get; set; }
        public bool DealerType { get; set; }
     
        public int DealerID { get; set; }
        public VehicleCompany? VehicleCompany { get; set; }
        public int VehicleCompanyID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
