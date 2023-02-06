using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Command.Create
{
    public class Create_Airport_Commands : IRequest<Create_Airport_CommandsResponse>
    {

        public string AirportName { get; set; }
        public int CityID { get; set; }
        public int RegionID { get; set; }

    }
}
