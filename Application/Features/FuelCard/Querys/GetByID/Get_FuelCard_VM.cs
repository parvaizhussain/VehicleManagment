using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelCard.Querys.GetByID
{
    public class Get_FuelCard_VM
    {
        public int CardID { get; set; }
        public string CardName { get; set; }
        public string CardNum { get; set; }
        public int CardLimit { get; set; }
        public string IssueDate { get; set; }
        public string ExipryDate { get; set; }
    }
}
