using CQRS.Application.Functions.Categories.Queries.GetCategoriesWithPost;
using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Contracts.Persistance
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithPost(SearchCategoryOptions searchOptions);
    }
}
