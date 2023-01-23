using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Models
{
    public class Branch
    {

        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public string NormalizedName { get; set; }
        public string BranchCode { get; set; }

        public int NetworkId { get; set; }

        public Network Network { get; set; }

        public bool IsDeleted { get; set; }

    }
}
