
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Command.Create
{
    public class Create_VehicleRequest_CommandsValidator : AbstractValidator<Create_VehicleRequest_Commands>
    {
        public Create_VehicleRequest_CommandsValidator()
        {
           
        }
    }
}
