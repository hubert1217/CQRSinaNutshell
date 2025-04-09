using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Functions.Webinars.Queries.GetWebinarList
{
    public class GetWebinarListQuery : IRequest<List<WebinarListViewModel>>
    {
    }
}
