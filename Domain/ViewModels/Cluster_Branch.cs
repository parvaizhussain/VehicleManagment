using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class Cluster_Branch
    {
        public int Cluster_BranchId { get; set; }
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
