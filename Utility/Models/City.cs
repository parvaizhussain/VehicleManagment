using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; }
        public string? NormalizedName { get; set; }

        public string? CityCode { get; set; }
        public int RegionID { get; set; }
        public Region? Region { get; set; }
    }
}
