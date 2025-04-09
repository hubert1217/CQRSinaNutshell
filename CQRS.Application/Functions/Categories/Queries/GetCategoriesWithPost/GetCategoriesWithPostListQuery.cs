using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Categories.Queries.GetCategoriesWithPost
{
    public class GetCategoriesWithPostListQuery : IRequest<List<CategoryPostListViewModel>>
    {
        public SearchCategoryOptions searchCategory { get; set; } 
    }

    public enum SearchCategoryOptions 
    { 
        All = 0,
        FirstBestThisMonth = 2,
        FirstBestAllTheTime = 3,
    }
}
