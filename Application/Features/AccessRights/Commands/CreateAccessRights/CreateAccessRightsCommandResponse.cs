using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Features.AccessRights.Commands.CreateAccessRights
{
   public  class CreateAccessRightsCommandResponse : BaseResponse
    {
        public CreateAccessRightsCommandResponse() : base()
        {

        }

        public CreateAccessRightsDto AccessRights { get; set; }
    }
}
