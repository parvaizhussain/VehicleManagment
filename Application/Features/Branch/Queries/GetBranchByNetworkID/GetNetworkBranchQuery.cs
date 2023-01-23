using Application.Features.Branch.Queries.GetBranchByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Branch.Queries.GetBranchByNetworkID
{
    public class GetNetworkBranchQuery : IRequest<List<GetBranchVM>>
    {
        public int NetworkId { get; set; }
       // public string NormalizedName { get; set; }
    }
}
