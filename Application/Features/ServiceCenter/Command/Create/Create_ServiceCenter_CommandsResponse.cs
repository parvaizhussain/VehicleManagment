using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Command.Create
{
    public class Create_ServiceCenter_CommandsResponse : BaseResponse
    {
        public Create_ServiceCenter_CommandsResponse() : base()
        {

        }

        public Create_ServiceCenter_Dto _ServiceCenter_Dto { get; set; }
    }
}
