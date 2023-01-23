using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class City : AuditableEntity
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public string CityCode { get; set; }

        public string NormalizedName { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}