
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Querys.GetByID
{
    public class Get_Driver_Query : IRequest<Get_Driver_VM>
    {
        public int DriverID { get; set; }
      
    }
}
