using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Command.UpdateManagerAprroval
{
    public class UpdateManagerAprrovalCommands : IRequest
    {
        public int RequestID { get; set; }
        public int Status { get; set; }
        public string? Remarks { get; set; }
       
    }
}
