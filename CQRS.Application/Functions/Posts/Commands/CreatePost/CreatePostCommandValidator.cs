using CQRS.Application.Contracts.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        private readonly IPostRepository _postRepository;

        public CreatePostCommandValidator()
        {
        }

        public CreatePostCommandValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;

            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(80)
                .WithMessage("{PropertyName} must not exceed 80 characters");
                

            RuleFor(p => p)
                .MustAsync(IsNameAndAuthorAlreadyExist)
                .WithMessage("Post with the same Title and Author already exist");

            RuleFor(p => p.Date)
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .NotNull()
                .LessThan(DateTime.Now.AddDays(1));

            RuleFor(p => p.Rate)
                .InclusiveBetween(0, 100)
                .WithMessage("{PropertyName} is between 0 to 100");
        }

        private async Task<bool> IsNameAndAuthorAlreadyExist(CreatePostCommand e, CancellationToken cancelationToken) 
        {
            var check = await _postRepository.IsNameAndAuthorAlreadyExist(e.Title, e.Author);

            return !check;
        }
    }
}
