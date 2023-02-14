using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Responses;

namespace Application.Features.FuelCard.Command.Create
{
    public class Create_FuelCard_CommandsResponse : BaseResponse
    {
        public Create_FuelCard_CommandsResponse() : base()
        {

        }

        public Create_FuelCard_Dto _FuelCard_Dto { get; set; }
    }
}
