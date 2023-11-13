using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using GymApp.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Infrastructure.UserRepository;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly GymAppContext _context;
        private readonly IUserRepository _userRepo;

        public AuthController(GymAppContext context, IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login model)
        {
            var user = _userRepo.GetUser(model.UserName);
            if (user == null)
                return BadRequest("Username or Password was wrong");

            //Hasha härss
            if(model.UserName == user.UserName && model.Password == user)

            return Ok();
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Register model)
        {
            if (model.Password != model.PasswordConfirm)
                return BadRequest("Passwords dont match");

            using (HMACSHA512 hmac = new())
            {

                var user = new User(model.UserName, hmac.Key, hmac.ComputeHash(System.
                Text.Encoding.UTF8.GetBytes(model.Password)))
                { };

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}