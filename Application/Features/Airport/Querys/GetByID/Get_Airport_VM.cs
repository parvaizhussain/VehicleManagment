using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Querys.GetByID
{
    public class Get_Airport_VM
    {
        public int AirportID { get; set; }
        public string AirportName { get; set; }
      //  public int CityID { get; set; }
        //public int RegionID { get; set; }
        public bool IsDeleted { get; set; }
        public Domain.Entities.City City { get; set; }
        public Domain.Entities.Region Region { get; set; }
        public bool IsActive { get; set; }
    }
}
