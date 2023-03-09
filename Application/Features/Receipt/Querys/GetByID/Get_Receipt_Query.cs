using Application.Features.VehicleBrands.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Querys.GetByID
{
    public class Get_Receipt_Query : IRequest<Get_Receipt_VM>
    {
        public int ReceiptId { get; set; }
    }
}
