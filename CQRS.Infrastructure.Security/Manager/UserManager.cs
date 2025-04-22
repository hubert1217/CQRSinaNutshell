using CQRS.Application.Security.Contracts;
using CQRS.Application.Security.Models;
using CQRS.Infrastructure.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Security.Manager
{
    public class UserManager : IUserManager<User>
    {
        public Task<UserManagerResult> CreateAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindByEmailAsync(string email)
        {
            string toLower = email.ToLowerInvariant();
            var user = StaticUserList.Users().FirstOrDefault(u => u.Email.ToLowerInvariant() == toLower);

            return Task.FromResult(user);
        }

        public Task<List<Claim>> GetClaimsAsync(User user)
        {
            Claim c = new Claim("MyCos", "MyValue");
            var list = new List<Claim>();
            list.Add(c);
            return Task.FromResult(list);
        }

        public Task<List<string>> GetRolesAsync(User user)
        {
            string c = "User";
            var list = new List<string>();
            list.Add(c);
            return Task.FromResult(list);
        }
    }
}
