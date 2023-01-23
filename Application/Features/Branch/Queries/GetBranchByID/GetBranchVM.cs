using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Branch.Queries.GetBranchByID
{
    public class GetBranchVM
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string NormalizedName { get; set; }
        public string BranchCode { get; set; }
        public bool IsDeleted { get; set; }
        public Domain.Entities.Network Network { get; set; }
    }
}
