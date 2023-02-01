using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Command.Create
{
    public class Create_ServiceCenter_Commands : IRequest<Create_ServiceCenter_CommandsResponse>
    {
        
        public string? ServiceCenterName { get; set; }
        public string? ContactNo { get; set; }
        public string? ContactPersonName { get; set; }
        public bool DealerType { get; set; }
        public int DealerID { get; set; }
        
    }
}
