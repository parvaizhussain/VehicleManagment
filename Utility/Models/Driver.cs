using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
	public class Driver
	{
		public int DriverID { get; set; }
		public int DriverERP { get; set; }
		public string? DriverName { get; set; }
		public string? DriverContact { get; set; }
		public string? DriverCNIC { get; set; }
		public string? DriverLicense { get; set; }
		public byte[]? DriverImage { get; set; }
		public int RegionID { get; set; }
		
		public Region? Region { get; set; }
		public int CityID { get; set; }

        //public City? City { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
