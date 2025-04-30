using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Application.Functions.Categories.Queries.GetCategoriesWithPost;
using CQRS.Application.Mapper;
using CQRS.Application.Tests.NUnit2.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Application.Tests.NUnit2.Categories.Queries
{
    public class GetCategoriesWithPosts
    {
        private Mock<ICategoryRepository> _categoryRepositoryMock = null!;
        private IMapper _mapper;

        [SetUp]
        public void SetUp() 
        {
            _categoryRepositoryMock = RepositoryMocks.GetCategoryRepository();

            var configurationprovider = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            _mapper = configurationprovider.CreateMapper();
            
        }

        [TearDown]
        public void TearDown()
        {
            _categoryRepositoryMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task GetCategoiriesWithPost() 
        {

            //_categoryRepositoryMock.Verify(repo => repo.GetCategoriesWithPost(SearchCategoryOptions.All), Times.Once);


            var handler = new GetCategoriesWithPostListQueryHandler(_mapper, _categoryRepositoryMock.Object);
            var request = new GetCategoriesWithPostListQuery() { searchCategory = SearchCategoryOptions.All };

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.That(result, Is.Not.Null);

            _categoryRepositoryMock.Verify(a=>a.GetCategoriesWithPost(SearchCategoryOptions.All), Times.Never );
        }

    }
}
