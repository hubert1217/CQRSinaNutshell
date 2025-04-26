using AutoMapper;
using CQRS.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Webinars.Queries.GetWebinarListByDate
{
    public class GetWebinarsByDateQueryHandler : IRequestHandler<GetWebinarsByDateQuery, PageWebinarByDateViewModel>
    {
        private readonly IWebinarRepository _webinarRepository;
        private readonly IMapper _mapper;

        public GetWebinarsByDateQueryHandler(IWebinarRepository webinarRepository, IMapper mapper)
        {
            _webinarRepository = webinarRepository;
            _mapper = mapper;
        }

        public async Task<PageWebinarByDateViewModel> Handle(GetWebinarsByDateQuery request, CancellationToken cancellationToken)
        {
            var webinarsByDate = await _webinarRepository.GetPagedWebinarsForDate(request.Option, request.Page, request.PageSize, request.Date);

            var webinars = _mapper.Map<List<WebinarsByDateViewModel>>(webinarsByDate);

            var count = await _webinarRepository.GetTotalCountOfWebinarsForDate(request.Option, request.Page, request.PageSize, request.Date);


            return new PageWebinarByDateViewModel()
            {
                AllCount = count,
                Page = request.Page,
                PageSize = request.PageSize,
                Webinars = webinars
            };
        }
    }
}
