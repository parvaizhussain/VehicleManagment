using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Command.Create
{
    public class Create_Receipt_CommandsResponse : BaseResponse
    {
        public Create_Receipt_CommandsResponse() : base()
        {

        }

        public Create_Receipt_Dto _Create_Receipt_Dto { get; set; }
    }
}
