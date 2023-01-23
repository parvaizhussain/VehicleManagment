using Application.Features.Branch.Queries.GetBranchByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Branch.Queries.GetBranchByRegionID
{
    public class GetRegionBranchQuery : IRequest<object>
    {
        public int RegionId { get; set; }
    }
}
