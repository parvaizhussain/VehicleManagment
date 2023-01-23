using Application.Features.City.Commands.UpdateCity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Command.Update
{
    public class Update_VehicleCompany_CommadsValidators : AbstractValidator<Update_VehicleCompany_Commads>
    {
        public Update_VehicleCompany_CommadsValidators()
        {
            RuleFor(p => p.VehicleCompanyName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


        }
    }
}