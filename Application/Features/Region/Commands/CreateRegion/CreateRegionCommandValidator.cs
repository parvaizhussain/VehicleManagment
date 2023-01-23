using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Features.Region.Commands.CreateRegion
{
    public class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
    {
        public CreateRegionCommandValidator()
        {
            RuleFor(p => p.RegionName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.NormalizedName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();


        }
    }
}


