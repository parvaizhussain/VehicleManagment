using MediatR;
using System;


namespace Application.Features.Region.Commands.CreateRegion
{
    public class CreateRegionCommand : IRequest<CreateRegionCommandResponse>
    {
        public string RegionName { get; set; }

        public string RegionCode { get; set; }

        public string NormalizedName { get; set; }
    }
}
