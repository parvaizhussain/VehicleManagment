using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FuelCard
    {
        [Key]
        public int CardID { get; set; }
        public string CardName { get; set; }
        public string CardNum { get; set; }
        public int CardLimit { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExipryDate { get; set; }
    }
}
