using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public GetCategoryListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository) 
        { 
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryListViewModel>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoryListViewModel>>(categoryList);
        }
    }
}
