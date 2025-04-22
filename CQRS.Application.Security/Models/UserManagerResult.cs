using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Security.Models
{
    public class UserManagerResult
    {
        public bool Succeeded { get; protected set; }
        public List<string>? Errors { get; private set; }
        public static UserManagerResult Success { get; } = new UserManagerResult() { Succeeded = true };
        public static UserManagerResult Failed(List<string> errors)
        {
            return new UserManagerResult() { Succeeded = true, Errors = errors };
        }
    }
}
