
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Command.Create
{
    public class Create_VehicleCompany_CommandsValidator : AbstractValidator<Create_VehicleCompany_Commands>
    {
        public Create_VehicleCompany_CommandsValidator()
        {
            RuleFor(p => p.VehicleCompanyName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }
    }
}
