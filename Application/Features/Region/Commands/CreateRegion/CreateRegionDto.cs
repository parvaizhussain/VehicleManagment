using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Region.Commands.CreateRegion
{
    public class CreateRegionDto
    {
        public string RegionName { get; set; }

        public string NormalizedName { get; set; }
    }
}
