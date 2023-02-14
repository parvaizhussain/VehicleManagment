using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Querys.GetByList
{
    public class Get_ServiceCenter_ListVM
    {
        public int ServiceCenterId { get; set; }
        public string? ServiceCenterName { get; set; }
        public string? ContactNo { get; set; }
        public string? ContactPersonName { get; set; }
        public bool DealerType { get; set; }
    
        public int DealerID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Domain.Entities.VehicleCompany? VehicleCompany { get; set; }
    }
}
