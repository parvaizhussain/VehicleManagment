﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class Region
    {
        public int RegionId { get; set; }

        public string RegionName { get; set; }

        public string NormalizedName { get; set; }

        public string RegionCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
