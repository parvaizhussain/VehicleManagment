using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Branch.Commands.CreateBranch
{
    public class CreateBranchDto
    {
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string NormalizedName { get; set; }
        public Domain.Entities.Network Network { get; set; }
    }
}
