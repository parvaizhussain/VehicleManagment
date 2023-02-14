using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class Airport
    {

        public int AirportID { get; set; }
        public string AirportName { get; set; }
        public int CityID { get; set; }
        public City? City { get; set; }
        public int RegionID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Region? Region { get; set; }



    }
}
