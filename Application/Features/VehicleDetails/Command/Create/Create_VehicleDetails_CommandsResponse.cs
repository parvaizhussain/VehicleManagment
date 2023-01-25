
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Command.Create
{
    public class Create_VehicleDetails_CommandsResponse : BaseResponse
    {
        public Create_VehicleDetails_CommandsResponse() : base()
        {

        }

        public Create_VehicleDetails_Dto _VehicleDetails_Dto { get; set; }
    }
}
