using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Posts.Queries.GetPostDetail
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery, PostDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public GetPostDetailQueryHandler(IMapper mapper, IAsyncRepository<Post> postRepository, IAsyncRepository<Category> categoryRepository)
        { 
            _mapper = mapper;
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<PostDetailViewModel> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);
            var category = await _categoryRepository.GetByIdAsync(post.CategoryId);

            var postDetail = _mapper.Map<PostDetailViewModel>(post);

            postDetail.Category = _mapper.Map<CategoryDto>(category);

            return postDetail;
        }
    }
}
