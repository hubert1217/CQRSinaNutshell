using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Application.Functions.Categories.Queries.GetCategoriesWithPost;
using CQRS.Application.Mapper;
using CQRS.Application.Tests.Mock;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Tests.Categories.Queries
{
    public class GetCategoriesWithPostTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetCategoriesWithPostTests() 
        { 
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesWithPostTest() 
        {
            var handler = new GetCategoriesWithPostListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var request = new GetCategoriesWithPostListQuery { searchCategory = SearchCategoryOptions.All };


            var response = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(response);
            Assert.Single(response);
        }
    }
}
