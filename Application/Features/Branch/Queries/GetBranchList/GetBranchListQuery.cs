using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Branch.Queries.GetBranchList
{
    public class GetBranchListQuery : IRequest<List<GetBranchListVM>>
    {
    }
}
