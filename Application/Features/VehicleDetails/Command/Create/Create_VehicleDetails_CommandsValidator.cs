
using Application.Features.VehicleBrands.Command.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Command.Create
{
    public class Create_VehicleDetails_CommandsValidator : AbstractValidator<Create_VehicleDetails_Commands>
    {
        public Create_VehicleDetails_CommandsValidator()
        {
            RuleFor(p => p.VehicleERP)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.VehicleNum)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
            RuleFor(p => p.VehicleModel)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

        }
    }
}