using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelCard.Command.Create
{
    public class Create_FuelCard_Commands : IRequest<Create_FuelCard_CommandsResponse>
    {
        public string CardName { get; set; }
        public string CardNum { get; set; }
        public int CardLimit { get; set; }
        public string IssueDate { get; set; }
        public string ExipryDate { get; set; }
    }
}
