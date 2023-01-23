using MediatR;
using System;

namespace Application.Features.City.Commands.UpdateCity
{
    public class UpdateCityCommand : IRequest
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public string NormalizedName { get; set; }

        public int RegionId { get; set; }

    }
}
