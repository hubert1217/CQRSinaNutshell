using CQRS.Application.Contracts.Persistance;
using CQRS.Application.Functions.Categories.Queries.GetCategoriesWithPost;
using CQRS.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Tests.NUnit.Mocks
{
    public static class RepositoryMocks
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = GetCategories();

            var mockCategoryRepository = new Mock<ICategoryRepository>();

            mockCategoryRepository
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(categories);

            mockCategoryRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Category>()))
                .ReturnsAsync((Category category) =>
            {
                categories.Add(category);
                return category;
            });

            mockCategoryRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    var category = categories.FirstOrDefault(c => c.CategoryId == id);

                    return category ?? throw new KeyNotFoundException($"{typeof(Category).Name} with id {id} not found.");
                });

            mockCategoryRepository
                .Setup(repo => repo.UpdateAsync(It.IsAny<Category>()))
                .Callback<Category>((entity) => { categories.Remove(entity); categories.Add(entity); });

            mockCategoryRepository
                .Setup(repo => repo.DeleteAsync(It.IsAny<Category>()))
                .Callback<Category>((entity) => categories.Remove(entity));

            mockCategoryRepository.Setup(repo => repo.GetCategoriesWithPost(It.IsAny<SearchCategoryOptions>())).ReturnsAsync(categoriesWithPost);

            return mockCategoryRepository;
        }

        private static List<Category> GetCategories()
        {
            return new List<Category> { MockedCategory };
        }

        private static Category MockedCategory => new() { CategoryId = 1, DisplayName = "TestName", Name = "TestName" };

        private static List<Post> mockedPostList => new() { new Post { PostId = 1, Author = "Test", Title = "Title", Description = "Description" } };

        private static List<Category> categoriesWithPost = new()
        {
            new Category { CategoryId = 1, DisplayName = "TestName", Name = "TestName", Posts = mockedPostList }
        };
}
}
