using Application.Features.Branch.Queries.GetBranchByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Branch.Queries.GetBranchByShortName
{
    public class GetBranchByShortNameQuery : IRequest<GetBranchVM>
    {
        public string ShortName { get; set; }
    }
}
