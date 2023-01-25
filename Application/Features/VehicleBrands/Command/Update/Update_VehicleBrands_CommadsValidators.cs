using Application.Features.VehicleBrands.Command.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Update
{
    public class Update_VehicleBrands_CommadsValidators : AbstractValidator<Update_VehicleBrands_Commads>
    {
        public Update_VehicleBrands_CommadsValidators()
        {
            RuleFor(p => p.VehicleBrandId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
            RuleFor(p => p.VehicleBrandName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.VehicleCompanyId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();


        }
    }
}