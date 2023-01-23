using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Branch : AuditableEntity
    {
        [Key]
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string NormalizedName { get; set; }
        public string BranchCode { get; set; }
        public int NetworkId { get; set; }
        public virtual Network Network { get; set; }

    }
}