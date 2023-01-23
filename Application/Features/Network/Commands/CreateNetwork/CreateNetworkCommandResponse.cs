using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Features.Network.Commands.CreateNetwork
{
   public  class CreateNetworkCommandResponse : BaseResponse
    {
        public CreateNetworkCommandResponse() : base()
        {

        }

        public CreateNetworkDto Network { get; set; }
    }
}
