
using Application.Features.VehicleBrands.Command.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Create
{
    public class Create_VehicleBrands_CommandsValidator : AbstractValidator<Create_VehicleBrands_Commands>
    {
        public Create_VehicleBrands_CommandsValidator()
        {
            RuleFor(p => p.VehicleBrandName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.VehicleCompanyId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

        }
    }
}
