using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Login
{
    public class Login
    {
        public string Name { get; set; } = null!;
        public string OpenDiIssuer { get; set; } = null!;
        public string OpenDISecret { get; set; } = null!;
    }
}