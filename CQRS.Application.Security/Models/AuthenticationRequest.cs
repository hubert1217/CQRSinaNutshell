﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Security.Models
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
    }
}
