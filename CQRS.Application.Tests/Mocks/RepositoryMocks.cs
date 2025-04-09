using CQRS.Application.Contracts.Persistance;
using CQRS.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Tests.Mock
{
    public static class RepositoryMocks
    {
        public static Mock<ICategoryRepository> GetCategoryRepository() 
        {
            var categories = GetCategories();

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
            {
                categories.Add(category);
                return category;
            });

            return mockCategoryRepository;
        }

        private static List<Category> GetCategories()
        {
            return new List<Category> { MockedCategory };
        }

        private static Category MockedCategory => new() { CategoryId = 1, DisplayName = "TestName", Name = "TestName" };
}
}
