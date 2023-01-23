using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Features.Network.Commands.CreateNetwork
{
    public class CreateNetworkCommandValidator : AbstractValidator<CreateNetworkCommand>
    {
        public CreateNetworkCommandValidator()
        {
            RuleFor(p => p.NetworkName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.NormalizedName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.CityId)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();
        }
    }
}
