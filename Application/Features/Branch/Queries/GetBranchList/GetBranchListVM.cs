using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Branch.Queries.GetBranchList
{
    public class GetBranchListVM
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string NormalizedName { get; set; }
        public string BranchCode { get; set; }
        public Domain.Entities.Network Network { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}


