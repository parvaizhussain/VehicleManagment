using MediatR;
using System;

namespace Application.Features.Branch.Commands.UpdateBranch
{
    public class UpdateBranchCommand : IRequest
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string NormalizedName { get; set; }
        public string BranchCode { get; set; }
        public int NetworkId { get; set; }
    }
}
