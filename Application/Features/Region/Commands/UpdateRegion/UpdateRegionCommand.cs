using MediatR;
using System;

namespace Application.Features.Region.Commands.UpdateRegion
{
    public class UpdateRegionCommand : IRequest
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public string RegionCode { get; set; }

        public string NormalizedName { get; set; }
    }
}
