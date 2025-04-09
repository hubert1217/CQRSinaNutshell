using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {

        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(2).MaximumLength(15)
                .WithMessage("{PropertyName} Length is between 2 and 15");

            RuleFor(p => p.DisplayName)
                .NotEmpty()
                .MinimumLength(2).MaximumLength(15)
                .WithMessage("{PropertyName} Length is between 2 and 15");
        }
    }
}
