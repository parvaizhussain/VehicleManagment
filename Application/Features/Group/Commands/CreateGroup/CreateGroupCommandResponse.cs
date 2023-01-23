using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Features.Group.Commands.CreateGroup
{
   public  class CreateGroupCommandResponse : BaseResponse
    {
        public CreateGroupCommandResponse() : base()
        {

        }

        public CreateGroupDto Group { get; set; }
    }
}
