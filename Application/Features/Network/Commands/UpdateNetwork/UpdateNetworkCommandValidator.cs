using FluentValidation;

namespace Application.Features.Network.Commands.UpdateNetwork
{
    public class UpdateNetworkCommandValidator : AbstractValidator<UpdateNetworkCommand>
    {
        public UpdateNetworkCommandValidator()
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
