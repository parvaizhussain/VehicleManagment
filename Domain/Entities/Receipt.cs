using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Receipt : AuditableEntity
    {
        [Key]
        public int ReceiptId { get; set; }
        public int BookingMID { get; set; }
        public int ReceiptNo { get; set;}
        public int ReceiptDate { get; set; }
        public int Amount { get; set; }
        public int Type { get; set; }
    }
}
