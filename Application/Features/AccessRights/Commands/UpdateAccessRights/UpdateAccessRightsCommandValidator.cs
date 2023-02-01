using FluentValidation;

namespace Application.Features.AccessRights.Commands.UpdateAccessRights
{
    public class UpdateAccessRightsCommandValidator : AbstractValidator<UpdateAccessRightsCommand>
    {
        public UpdateAccessRightsCommandValidator()
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
