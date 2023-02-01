using System;
using FluentValidation;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.AccessRights.Commands.CreateAccessRights
{
    public class CreateAccessRightsCommandValidator : AbstractValidator<CreateAccessRightsCommand>
    {
        public CreateAccessRightsCommandValidator()
        {
            RuleFor(p => p.AccessName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.NormalizedName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();
        }
    }
}
