using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Categories.Queries.GetCategoriesWithPost
{
    public class CategoryPostListViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public ICollection<CategoryPostDto> Posts { get; set; }
    }
}
