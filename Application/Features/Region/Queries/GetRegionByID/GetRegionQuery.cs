using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Region.Queries.GetRegionByID
{
    public class GetRegionQuery : IRequest<GetRegionVM>
    {
        public int RegionId { get; set; }
    }
}
