using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Application.Exceptions;
using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Post> _postRepository;

        public CreatePostCommandHandler(IMapper mapper, IAsyncRepository<Post> postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<CreatePostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) 
            {
                return new CreatePostCommandResponse(validatorResult);
            }

            var post = _mapper.Map<Post>(request);
            post = await _postRepository.AddAsync(post);

            return new CreatePostCommandResponse(post.PostId);
        }
    }
}
