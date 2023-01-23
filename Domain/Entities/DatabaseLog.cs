using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DatabaseLog
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string ExternalRequest { get; set; }
        public string ExternalResponse { get; set; }
        public string Error { get; set; }
        public int TransactionType { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }

        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
    }
}
