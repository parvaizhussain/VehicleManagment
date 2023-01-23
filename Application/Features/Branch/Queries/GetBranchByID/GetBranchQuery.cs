using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Branch.Queries.GetBranchByID
{
    public class GetBranchQuery : IRequest<GetBranchVM>
    {
        public int BranchId { get; set; }
    }
}
