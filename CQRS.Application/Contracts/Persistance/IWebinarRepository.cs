using CQRS.Application.Functions.Webinars.Queries.GetWebinarListByDate;
using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Contracts.Persistance
{
    public interface IWebinarRepository : IAsyncRepository<Webinar>
    {
        Task<List<Webinar>> GetPagedWebinarsForDate(SearchOptionsWebinars option, int page, int pageSize, DateTime? date);

        Task<int> GetTotalCountOfWebinarsForDate(SearchOptionsWebinars option, int page, int pageSize, DateTime? date);
    }
}
