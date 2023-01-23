using Application.Features.Branch.Queries.GetBranchByID;
using MediatR;
using System;

namespace Application.Features.Branch.Commands.DeleteBranch
{
    public class DeleteBranchCommand : IRequest<GetBranchVM>
    {
        public int BranchId { get; set; }
    }
}
