
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Command.Create
{
    public class Create_ServiceCenter_CommandsValidator : AbstractValidator<Create_ServiceCenter_Commands>
    {
        public Create_ServiceCenter_CommandsValidator()
        {
            RuleFor(p => p.ServiceCenterName).NotEmpty().WithMessage("{PropertyName} is Required").NotNull();
        }
    }
}
