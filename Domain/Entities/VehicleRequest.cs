using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VehicleRequest : AuditableEntity
    {
        [Key]
        public int RequestID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeContact { get; set; }

        [ForeignKey("RegionID")]
        public int RegionID { get; set; }
        public virtual Region Region { get; set; }
        public string Purpose { get; set; }
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan RequestTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan RequestEndTime { get; set; }
        public int Status { get; set; }
        public string? Remarks { get; set; }
        public bool HODApproval { get; set; }
        public string? HODEmpID { get; set; }
        public string IsAirport { get; set; }
        public string RequestType { get; set; }
        public string? FlightNo { get; set; }
        public string? TicketNo { get; set; }
        public byte[]? TicketPDF { get; set; }
        public string? PickFrom { get; set;}
        public string? PickTo { get; set; }
        public string? DropFrom { get; set; }
        public string? DropTo { get; set; }
        public int NoOfPassanger { get; set; }
        public bool IsLuggage { get; set; }

    }
}
