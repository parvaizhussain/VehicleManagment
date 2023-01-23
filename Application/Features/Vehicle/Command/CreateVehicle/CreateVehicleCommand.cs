
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicle.Command.CreateCommand
{
    public class CreateVehicleCommand : IRequest<CreateVehicleCommandReponse>
    {
       
        public int VehicleERP { get; set; }
        public string VehicleNum { get; set; }
        public string VehicleName { get; set; }
        public string VehicleType { get; set; }
        public string VehicleMilage { get; set; }
        public string VehicleModel { get; set; }
        public string FuelType { get; set; }
        public int RegionID { get; set; }
      
    }
}
