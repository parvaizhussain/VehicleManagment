using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Airport : AuditableEntity
    {
        [Key]
        public int AirportID { get; set; }
        public string AirportName { get; set; }
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }

		public int RegionID { get; set; }
		[ForeignKey("RegionID")]
		public virtual Region Region { get; set; }
	}
}
