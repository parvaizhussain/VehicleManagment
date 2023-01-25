using Application.Features.VehicleBrands.Command.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Command.Update
{
    public class Update_VehicleDetails_CommadsValidators : AbstractValidator<Update_VehicleDetails_Commads>
    {
        public Update_VehicleDetails_CommadsValidators()
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