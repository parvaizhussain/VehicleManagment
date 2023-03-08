using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookingDetail : AuditableEntity
    {
        [Key]
        public int BookingDID { get; set; }
        public int BookingMID { get; set; }
        public int RequestID { get; set; }
        public int SeatingCapacity { get; set; }
    }
}
