using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Region : AuditableEntity
    {
        [Key]
        public int RegionId { get; set; }

        public string RegionName { get; set; }

        public string NormalizedName { get; set; }

        public string RegionCode { get; set; }


    }
}
