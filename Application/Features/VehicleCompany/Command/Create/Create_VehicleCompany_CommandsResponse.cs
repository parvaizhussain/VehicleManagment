using Application.Features.City.Commands.CreateCity;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Command.Create
{
    public class Create_VehicleCompany_CommandsResponse : BaseResponse
    {
        public Create_VehicleCompany_CommandsResponse() : base()
        {

        }

        public Create_VehicleCompany_Dto _VehicleCompany_Dto { get; set; }
    }
}
