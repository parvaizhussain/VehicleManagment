using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintainaceHistory.Command.Create
{
    public class Create_MaintainaceHistory_CommandsResponse : BaseResponse
    {
        public Create_MaintainaceHistory_CommandsResponse() : base()
        {

        }

        public Create_MaintainaceHistory_Dto _MaintainaceHistory_Dto { get; set; }
    }
}
