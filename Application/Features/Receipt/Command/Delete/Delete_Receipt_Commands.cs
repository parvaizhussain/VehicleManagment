using Application.Features.Receipt.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Command.Delete
{
    public class Delete_Receipt_Commands : IRequest<Get_Receipt_VM>
    {
        public int ReceiptId { get; set; }
    }
}
