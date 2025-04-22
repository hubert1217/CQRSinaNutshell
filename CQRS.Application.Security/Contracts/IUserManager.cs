using CQRS.Application.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Security.Contracts
{
    public interface IUserManager<TUser> where TUser : class
    {
        Task<List<string>> GetRolesAsync(TUser user);
        Task<List<Claim>> GetClaimsAsync(TUser user);
        Task<TUser?> FindByEmailAsync(string email);
        Task<UserManagerResult> CreateAsync(TUser user, string password);

    }
}
