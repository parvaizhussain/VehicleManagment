using System;
using Application.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Command.Create
{
    public class Create_Driver_CommandsResponse: BaseResponse
    {
        public Create_Driver_CommandsResponse() : base()
        {

        }

        public Create_Driver_Dto _Create_Driver_Dto { get; set; }
    }
}
