using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class VehicleDetail : AuditableEntity
    {
        [Key]
        public int VehicleID { get; set; }
        public int VehicleERP { get; set; }
        [ForeignKey("VehicleCompanyId")]
        public int VehicleCompanyId { get; set; }
        public VehicleCompany VehicleCompany { get; set; }
        [ForeignKey("VehicleBrandID")]
        public int VehicleBrandID { get; set; }
        public VehicleBrands VehicleBrands { get; set; }
        public string VehicleNum { get; set; }
        public string VehicleName { get; set; }
        public string VehicleColor { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string VehicleType { get; set; }
        public string VehicleMilage { get; set; }
        public int VehicleCurrentKM { get; set; }
        public string VehicleModel { get; set; }
        public string FuelType { get; set; }
        public int RegionID { get; set; }
        [ForeignKey("RegionID")]
        public Region Region { get; set; }
        public int VehicleBrandsVehicleBrandId { get; set; }
        public int PersonCapacity { get; set; }
    }
}
