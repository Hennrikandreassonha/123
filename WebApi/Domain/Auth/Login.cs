using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Login
{
    public class Login
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }

    }
}