using Application.Features.Region.Queries.GetRegionByID;
using MediatR;
using System;

namespace Application.Features.Region.Commands.DeleteRegion
{
    public class DeleteRegionCommand : IRequest<GetRegionVM>
    {
        public int RegionId { get; set; }
    }
}
