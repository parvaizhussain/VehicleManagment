using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Application.Features.Group.Commands.CreateGroup
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(p => p.GroupName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.NormalizedName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.DepartmentId)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull();
        }
    }
}
