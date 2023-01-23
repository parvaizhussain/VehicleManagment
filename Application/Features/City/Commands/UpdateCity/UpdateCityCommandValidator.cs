using FluentValidation;

namespace Application.Features.City.Commands.UpdateCity
{
    public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityCommandValidator()
        {
            RuleFor(p => p.CityName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.NormalizedName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.RegionId)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();
        }
    }
}