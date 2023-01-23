using MediatR;
using System;


namespace Application.Features.Branch.Commands.CreateBranch
{
   public  class CreateBranchCommand : IRequest<CreateBranchCommandResponse>
    {
        public string BranchName { get; set; }
        public string NormalizedName { get; set; }

        public string BranchCode { get; set; }
        public int NetworkId { get; set; }
    }
}
