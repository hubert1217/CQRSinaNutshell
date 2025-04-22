using CQRS.Application.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Security.Contracts
{
    public interface ISignInManager<TUser> where TUser : class
    {
        Task<SignInResult> PasswordSighInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailture);

    }
}
