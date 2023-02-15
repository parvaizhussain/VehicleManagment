using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelCard.Command.Update
{
    public class Update_FuelCard_Commands : IRequest
    {
        public int CardID { get; set; }
        public string CardName { get; set; }
        public string CardNum { get; set; }
        public int CardLimit { get; set; }
        public string IssueDate { get; set; }
        public string ExipryDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
