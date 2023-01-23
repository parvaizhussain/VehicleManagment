using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Network : AuditableEntity
    {
        [Key]
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string NormalizedName { get; set; }
        //FAHAD Changes
        public string RegionCode { get; set; }
        //FAHAD Changes
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}