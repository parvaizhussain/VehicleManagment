
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.VehicleDetails.Querys.GetByID;

namespace Application.Features.VehicleDetails.Command.Delete
{
    public class Delete_VehicleDetails_Commands : IRequest<Get_VehicleDetails_VM>
    {
       
        public int VehicleID { get; set; }
     
    }
}
