using AutoMapper;
using CQRS.Application.Functions.Categories.Commands.CreateCategory;
using CQRS.Application.Functions.Categories.Queries.GetCategoriesWithPost;
using CQRS.Application.Functions.Categories.Queries.GetCategoryList;
using CQRS.Application.Functions.Posts.Commands.CreatePost;
using CQRS.Application.Functions.Posts.Commands.UpdatePost;
using CQRS.Application.Functions.Posts.Queries.GetPostDetail;
using CQRS.Application.Functions.Posts.Queries.GetPostList;
using CQRS.Application.Functions.Webinars.Queries.GetWebinarList;
using CQRS.Application.Functions.Webinars.Queries.GetWebinarListByDate;
using CQRS.Domain.Entities;

namespace CQRS.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Post, PostInListViewModel>().ReverseMap();
            CreateMap<Post, PostDetailViewModel>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            CreateMap<Post, CategoryPostDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListViewModel>().ReverseMap();
            CreateMap<Category, CategoryPostListViewModel>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();

            CreateMap<Webinar, WebinarListViewModel>().ReverseMap();
            CreateMap<Webinar, WebinarsByDateViewModel>().ReverseMap();


        }
    }
}
