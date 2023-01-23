using Application.Features.City.Commands.CreateCity;
using Application.Features.Vehicle.Command.CreateVehicle;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicle.Command.CreateCommand
{
    public class CreateVehicleCommandReponse : BaseResponse
    {
        public CreateVehicleCommandReponse() : base()
        {

        }

        public CreateVehicleDto VehicleDto { get; set; }
    }
}
