using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Region.Queries.GetRegionList
{
    public class GetRegionListVM
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public string NormalizedName { get; set; }

        public string RegionCode { get; set; }

        public bool IsDeleted { get; set;}
        public bool IsActive { get; set;}
    }
}


