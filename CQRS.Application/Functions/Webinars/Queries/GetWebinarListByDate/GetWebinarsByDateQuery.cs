using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Webinars.Queries.GetWebinarListByDate
{
    public class GetWebinarsByDateQuery : IRequest<PageWebinarByDateViewModel>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public SearchOptionsWebinars Option { get; set; }
    }
}
