using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Querys.GetByList
{
    public class Get_VehicleRequest_ListVM
    {
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeContact { get; set; }

        public int RegionID { get; set; }
        public Domain.Entities.Region Region { get; set; }
        public string Purpose { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }
       // [DataType(DataType.Time)]
        public string RequestTime { get; set; }
        public int Status { get; set; }
        public string? Remarks { get; set; }
        public bool HODApproval { get; set; }
        public string? HODEmpID { get; set; }
        public string IsAirport { get; set; }
        public string? RequestType { get; set; }

        public string? FlightNo { get; set; }
        public string? TicketNo { get; set; }
        public byte[]? TicketPDF { get; set; }
        public string? PickFrom { get; set; }
        public string? PickTo { get; set; }
        public string? DropFrom { get; set; }
        public string? DropTo { get; set; }
        public int NoOfPassanger { get; set; }
        public bool IsLuggage { get; set; }

        public TimeSpan RequestEndTime { get; set; }
    }
}
