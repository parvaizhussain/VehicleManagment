using Application.Features.City.Commands.CreateCity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehicle.Command.CreateCommand
{
    internal class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(p => p.VehicleName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.VehicleERP)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull();

            RuleFor(p => p.VehicleNum)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull();

            RuleFor(p => p.VehicleMilage)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull();


        }
    }
}
