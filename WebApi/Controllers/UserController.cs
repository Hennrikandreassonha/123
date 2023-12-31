using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Users;
using WebApi.Infrastructure.Repository.Database;
using WebApi.Infrastructure.UserRepository;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] UserInputModel user)
        {
            if (user == null)
                return BadRequest(new { Message = "Fail" });

            if (await _userRepo.AddUser(user, true))
            {
                return Ok(new { Message = "Användare har lagts till" });
            }

            return BadRequest(new { Message = "Fail" });

        }

    }
}