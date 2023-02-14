using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class FuelCard
    {
        public int CardID { get; set; }
        public string CardName { get; set; }
        public string CardNum { get; set; }
        public int CardLimit { get; set; }
        public string IssueDate { get; set; }
        public string ExipryDate { get; set; }
    }
}
