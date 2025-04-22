﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Security.Models
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
