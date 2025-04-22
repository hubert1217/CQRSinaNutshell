using CQRS.Application.Functions.Categories.Queries.GetCategoriesWithPost;
using CQRS.Application.Functions.Posts.Queries.GetPostList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllPosts")]
        public async Task<ActionResult<List<PostInListViewModel>>> GetAllPosts() 
        {
            var list = await _mediator.Send(new GetPostsListQuery());
            return Ok(list);
        }
    }
}
