using MediatR;
using System;


namespace Application.Features.City.Commands.CreateCity
{
   public  class CreateCityCommand : IRequest<CreateCityCommandResponse>
    {
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string NormalizedName { get; set; }
        public int RegionId { get; set; }
    }
}
