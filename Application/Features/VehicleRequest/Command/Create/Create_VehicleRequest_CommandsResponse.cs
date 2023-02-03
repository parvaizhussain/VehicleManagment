using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Command.Create
{
    public class Create_VehicleRequest_CommandsResponse: BaseResponse
    {
        public Create_VehicleRequest_CommandsResponse() : base()
        {

        }

        public Create_VehicleRequest_Dto _VehicleRequest_Dto { get; set; }
    }
}
