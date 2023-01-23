using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.City.Commands.CreateCity
{
    public class CreateCityDto
    {
        public string CityName { get; set; }

        public string NormalizedName { get; set; }

        public Domain.Entities.Region Region { get; set; }
    }
}
