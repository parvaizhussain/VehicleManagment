using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Features.City.Commands.CreateCity
{
   public  class CreateCityCommandResponse : BaseResponse
    {
        public CreateCityCommandResponse() : base()
        {

        }

        public CreateCityDto City { get; set; }
    }
}
