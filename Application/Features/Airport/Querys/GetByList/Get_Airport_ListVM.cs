using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Airport.Querys.GetByList
{
    public class Get_Airport_ListVM
    {
        public int AirportID { get; set; }
        public string AirportName { get; set; }
        public int CityID { get; set; }

        public virtual  Domain.Entities.City City { get; set; }

        public int RegionID { get; set; }

        public virtual Domain.Entities.Region Region { get; set; }
    }
}
