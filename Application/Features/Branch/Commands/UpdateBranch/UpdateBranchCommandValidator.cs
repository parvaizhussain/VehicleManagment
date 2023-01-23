using FluentValidation;

namespace Application.Features.Branch.Commands.UpdateBranch
{
    public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
    {
        public UpdateBranchCommandValidator()
        {
            RuleFor(p => p.BranchName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.NormalizedName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.NetworkId)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();
        }
    }
}
