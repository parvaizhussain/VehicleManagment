using Application.Features.VehicleBrands.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintainaceHistory.Querys.GetByID
{
    public class Get_MaintainaceHistory_Query : IRequest<Get_MaintainaceHistory_VM>
    {
        public int MaintainaceHistoryId { get; set; }
    }
}
