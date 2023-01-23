using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Features.Region.Commands.CreateRegion
{
   public  class CreateRegionCommandResponse : BaseResponse
    {
        public CreateRegionCommandResponse() : base()
        {

        }

        public CreateRegionDto Region { get; set; }
    }
}
