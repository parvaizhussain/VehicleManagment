using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.City.Queries.GetCityList
{
    public class GetCityListVM
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string NormalizedName { get; set; }

        public Domain.Entities.Region Region { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}


