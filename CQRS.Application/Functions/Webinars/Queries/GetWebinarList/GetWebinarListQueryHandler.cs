using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Webinars.Queries.GetWebinarList
{
    public class GetWebinarListQueryHandler : IRequestHandler<GetWebinarListQuery, List<WebinarListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Webinar> _webinarRepository;

        public GetWebinarListQueryHandler(IMapper mapper, IAsyncRepository<Webinar> webinarRepository)
        {
            _mapper = mapper;
            _webinarRepository = webinarRepository;
        }

        public async Task<List<WebinarListViewModel>> Handle(GetWebinarListQuery request, CancellationToken cancellationToken)
        {
            var webinarList = await _webinarRepository.GetAllAsync();

            return _mapper.Map<List<WebinarListViewModel>>(webinarList);
        }
    }
}
