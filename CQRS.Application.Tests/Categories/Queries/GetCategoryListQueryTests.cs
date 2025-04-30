using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Application.Functions.Categories.Queries.GetCategoryList;
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
    public class GetCategoryListQueryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public GetCategoryListQueryTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }
            );
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetAllCategories() 
        {
            var handler = new GetCategoryListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var response = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.GetAllAsync();

            response.Count.Equals(allCategories.Count);
        }
    }
}
