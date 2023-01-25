using Application.Features.VehicleBrands.Command.Create;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Create
{
    public class Create_VehicleBrands_CommandsResponse : BaseResponse
    {
        public Create_VehicleBrands_CommandsResponse() : base()
        {

        }

        public Create_VehicleBrands_Dto _VehicleBrands_Dto { get; set; }
    }
}
