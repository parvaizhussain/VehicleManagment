using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Command.Update
{
    public class Update_Airport_Commads : IRequest
    {
        public int AirportID { get; set; }
        public string AirportName { get; set; }
        public int CityID { get; set; }
        public int RegionID { get; set; }
    }
}
