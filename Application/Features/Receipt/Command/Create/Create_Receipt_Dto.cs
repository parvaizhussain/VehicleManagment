using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Command.Create
{
    public class Create_Receipt_Dto
    {
        public int ReceiptId { get; set; }
        public int BookingMID { get; set; }
        public int ReceiptNo { get; set; }
        public int ReceiptDate { get; set; }
        public int Amount { get; set; }
        public int Type { get; set; }
    }
}
