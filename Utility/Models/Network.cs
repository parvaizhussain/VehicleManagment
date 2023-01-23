using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Models
{
    public class Network
    {
        public int NetworkId { get; set; }

        public string NetworkName { get; set; }

        public string NormalizedName { get; set; }

        public int CityId { get; set; }
        //public City City { get; set; }

        public bool IsDeleted { get; set; }
    }
}
