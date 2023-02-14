using Application.Features.MaintainaceHistory.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintainaceHistory.Command.Delete
{
    public class Delete_MaintainaceHistory_Commands : IRequest<Get_MaintainaceHistory_VM>
    {
        public int MaintainaceHistoryId { get; set; }
      
    }
}
