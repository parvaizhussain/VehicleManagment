using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.VehicleDetails.Command.Update
{
    public class Update_VehicleDetails_Commads : IRequest
    {
       
        public int VehicleID { get; set; }
        public int VehicleERP { get; set; }
        
       
        public int VehicleBrandID { get; set; }
        
        public string VehicleNum { get; set; }
        public string VehicleName { get; set; }
        public string VehicleColor { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string VehicleType { get; set; }
        public string VehicleMilage { get; set; }
        public string VehicleModel { get; set; }
        public string FuelType { get; set; }
        public int RegionID { get; set; }
       
    }
}
