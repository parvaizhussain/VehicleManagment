using Application.Features.VehicleBrands.Command.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Command.Update
{
    public class Update_ServiceCenter_CommadsValidators : AbstractValidator<Update_ServiceCenter_Commads>
    {
        public Update_ServiceCenter_CommadsValidators()
        {
            RuleFor(p => p.ServiceCenterName).NotEmpty().WithMessage("{PropertyName} is Required.").NotNull();


        }
    }
}