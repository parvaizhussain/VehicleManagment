using Application.Features.VehicleRequest.Command.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Command.UpdateManagerAprroval
{
    public class UpdateManagerAprrovalCommandValidator : AbstractValidator<UpdateManagerAprrovalCommands>
    {
        public UpdateManagerAprrovalCommandValidator()
        {

        }
    }
}