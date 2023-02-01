using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MaintainaceHistory : AuditableEntity
    {
        [Key]
        public int MaintainaceHistoryId { get; set; }
        public string? MaintainaceLocation { get; set; }
        [DataType(DataType.Date)]
        public DateTime MaintainaceDateForm { get; set; }
        [DataType(DataType.Date)]
        public DateTime MaintainaceDateTo { get; set; }
        public string? CarNumber { get; set; }
        public string? Issue { get; set; }
        public string? InvoiceNo { get; set; }
        public decimal Amount { get; set; }
    }
}
