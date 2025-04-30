using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Webinars.Commands.CreateWebinar
{
    public class CreateWebinarCommandValidator : AbstractValidator<CreateWebinarCommand>
    {
        public CreateWebinarCommandValidator() 
        {
            RuleFor(w => w.ImageUrl)
                .NotEmpty()
                .NotNull();

            RuleFor(w => w.Title)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(80);

            RuleFor(w => w.FacebookEventUrl)
                .NotEmpty()
                .NotNull();

            RuleFor(w => w.Date)
                .GreaterThan(DateTime.Now.AddYears(-1));
        }
    }
}
