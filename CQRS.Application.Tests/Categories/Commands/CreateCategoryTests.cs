using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Application.Functions.Categories.Commands.CreateCategory;
using CQRS.Application.Functions.Posts.Commands.CreatePost;
using CQRS.Application.Mapper;
using CQRS.Application.Tests.Mock;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Tests.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public CreateCategoryTests() 
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
        public async Task Handle_ValidCategory_AddToCategoryRepo() 
        {
            var handler = new CreateCategoryCommandHandler(_mapper ,_mockCategoryRepository.Object);

            var allCategoryBeforeCount = (await _mockCategoryRepository.Object.GetAllAsync()).Count();

            var command = new CreateCategoryCommand()
            {
                CategoryId = 1,
                Name = "TestName",
                DisplayName = "TestName",
            };

            var response = await handler.Handle(command, CancellationToken.None);

            var allCategory = await _mockCategoryRepository.Object.GetAllAsync();

            response.Success.ShouldBe(true);
        }
    }
}
