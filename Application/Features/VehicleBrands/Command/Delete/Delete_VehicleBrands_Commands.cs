
using Application.Features.VehicleBrands.Querys.GetByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Delete
{
    public class Delete_VehicleBrands_Commands : IRequest<Get_VehicleBrands_VM>
    {
           public int VehicleBrandId { get; set; }

       
    }
}
