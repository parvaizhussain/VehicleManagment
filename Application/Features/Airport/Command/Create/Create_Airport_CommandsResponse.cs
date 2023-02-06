using Application.Features.Airport.Command.Create;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Command.Create
{
    public class Create_Airport_CommandsResponse: BaseResponse
    {
        public Create_Airport_CommandsResponse () : base()
        {

        }

        public Create_Airport_Dto _Airport_Dto { get; set; }
    }
}
