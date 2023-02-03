using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Command.Create
{
    public class Create_Driver_Commands : IRequest<Create_Driver_CommandsResponse>
    {
        public int DriverERP { get; set; }
        public string? DriverName { get; set; }
        public string? DriverContact { get; set; }
        public string? DriverCNIC { get; set; }
        public string? DriverLicense { get; set; }
        public byte[]? DriverImage { get; set; }
        public int RegionID { get; set; }
        public int CityID { get; set; }
        
    }
}
