using System;
using System.Collections.Generic;
using System.Text;
using Application.Responses;

namespace Application.Features.Branch.Commands.CreateBranch
{
   public  class CreateBranchCommandResponse : BaseResponse
    {
        public CreateBranchCommandResponse() : base()
        {

        }

        public CreateBranchDto Branch { get; set; }
    }
}
