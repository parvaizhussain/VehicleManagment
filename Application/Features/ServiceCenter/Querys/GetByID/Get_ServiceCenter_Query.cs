
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Querys.GetByID
{
    public class Get_ServiceCenter_Query : IRequest<Get_ServiceCenter_VM>
    {
        public int ServiceCenterId { get; set; }
   
    }
}
