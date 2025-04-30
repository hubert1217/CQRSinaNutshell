using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Application.Functions.Categories.Commands.CreateCategory;
using CQRS.Application.Mapper;
using CQRS.Application.Tests.NUnit2.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Tests.NUnit2.Categories.Commands
{
    public class CreateCategoryTest
    {
        public IMapper _mapper = null!;
        public Mock<ICategoryRepository> _categoryRepository = null!;

        [SetUp]
        public void SetUp() 
        { 
            _categoryRepository = RepositoryMocks.GetCategoryRepository();

            var configurationProvider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            _mapper = configurationProvider.CreateMapper();
        }


        [Test]
        public async Task CanCreateCategory() 
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _categoryRepository.Object);

            var request = new CreateCategoryCommand()
            {
                CategoryId = 100,
                Name = "aa",
                DisplayName = "aaaa",
            };

            var result = await handler.Handle(request, CancellationToken.None);



            Assert.IsNotNull(result.CategoryId);
        }

        [Test]
        public async Task CantCreateCategory_ValidationError()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _categoryRepository.Object);

            var request = new CreateCategoryCommand()
            {
                CategoryId = 100,
                Name = "a",
                DisplayName = "aaaa",
            };

            var result = await handler.Handle(request, CancellationToken.None);



            Assert.That(result.ValidationErrors.Count, Is.GreaterThan(0));
            Assert.That(result.ValidationErrors[0], Is.EqualTo("The length of 'Name' must be at least 2 characters. You entered 1 characters."));
        }

        [Test]
        public async Task CantCreateCategory_EmptyName()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _categoryRepository.Object);

            var request = new CreateCategoryCommand()
            {
                CategoryId = 100,
                Name = "",
                DisplayName = "sfdfsfsfs",
            };

            var result = await handler.Handle(request, CancellationToken.None);



            Assert.That(result.ValidationErrors.Count, Is.GreaterThan(0));
            //Assert.That(result.ValidationErrors.Count, Is.EqualTo(2));
            Assert.That(result.ValidationErrors[0], Is.EqualTo("'Name' must not be empty."));
        }
    }
}
