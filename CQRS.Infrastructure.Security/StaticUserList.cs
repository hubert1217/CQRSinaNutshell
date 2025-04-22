using CQRS.Infrastructure.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Security
{
    public class StaticUserList
    {
        public static List<User> Users() 
        {
            List<User> list = new List<User>();

            User u = new User()
            {
                Email = "stefan@gmail.com",
                FirstName = "Stefan",
                LastName = "Kowalski",
                Id = "qwertyuiop",
                UserName = "skowalski"
            };

            list.Add(u);

            return list;
        }
    }
}
