using CQRS.Application.Security.Contracts;
using CQRS.Application.Security.Models;
using CQRS.Infrastructure.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Security.Manager
{
    public class SignInManager : ISignInManager<User>
    {
        public Task<SignInResult> PasswordSighInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailture)
        {
            if (password == "12345") 
            { 
                return Task.FromResult(SignInResult.Success);
            }
            else
            {
                return Task.FromResult(SignInResult.Fail);
            }
        }
    }
}
