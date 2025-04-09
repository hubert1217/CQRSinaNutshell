using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Contracts.Persistance
{
    public interface IPostRepository : IAsyncRepository<Post>
    {
        Task<bool> IsNameAndAuthorAlreadyExist(string title, string author);
    }
}
