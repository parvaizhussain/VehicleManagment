using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        public int DriverERP { get; set; }
        public string DriverName { get; set; }
        public string DriverContact { get; set; }
        public string DriverCNIC { get; set; }
        public string DriverLicense { get; set; }
        public byte[] DriverImage { get; set; }
        public int RegionID { get; set; }
        [ForeignKey("RegionID")]
        public Region Region { get; set; }
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
    }
}
