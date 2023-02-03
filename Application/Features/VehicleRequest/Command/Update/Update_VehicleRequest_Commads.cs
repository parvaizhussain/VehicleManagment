using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Command.Update
{
    public class Update_VehicleRequest_Commads : IRequest
    {
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeContact { get; set; }

        public int RegionID { get; set; }

        public string Purpose { get; set; }
        public DateTime Request { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
        public bool HODApproval { get; set; }
        public string IsAirport { get; set; }
        public string RequestType { get; set; }

        public string FlightNo { get; set; }
        public string TicketNo { get; set; }
        public byte[] TicketPDF { get; set; }
        public string PickFrom { get; set; }
        public string PickTo { get; set; }
        public string DropFrom { get; set; }
        public string DropTo { get; set; }
    }
}
