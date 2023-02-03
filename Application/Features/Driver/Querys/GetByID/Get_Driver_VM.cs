using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Querys.GetByID
{
    public class Get_Driver_VM
    {
        public int DriverID { get; set; }
        public int DriverERP { get; set; }
        public string DriverName { get; set; }
        public string DriverContact { get; set; }
        public string DriverCNIC { get; set; }
        public string DriverLicense { get; set; }
        public byte[] DriverImage { get; set; }
        public int RegionID { get; set; }
        public int CityID { get; set; }
    }
}
