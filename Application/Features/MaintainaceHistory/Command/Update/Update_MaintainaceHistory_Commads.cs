using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintainaceHistory.Command.Update
{
    public class Update_MaintainaceHistory_Commads : IRequest
    {
        public int MaintainaceHistoryId { get; set; }
        public string? MaintainaceLocation { get; set; }
        public DateTime MaintainaceDateForm { get; set; }
        public DateTime MaintainaceDateTo { get; set; }
        public string? CarNumber { get; set; }
        public string? Issue { get; set; }
        public string? InvoiceNo { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
