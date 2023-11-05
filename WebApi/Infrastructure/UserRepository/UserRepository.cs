using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Domain.Users;
using WebApi.Domain.Users;
using WebApi.Infrastructure.Repository.Database;

namespace WebApi.Infrastructure.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly GymAppContext _context;
        public UserRepository(GymAppContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUser(UserInputModel user, bool saveChanges = false)
        {
            if (user == null)
                return false;

            User userToAdd = new(user.Name, user.Email, user.PhoneNumber == "" ? user.PhoneNumber : "");
            await _context.Users.AddAsync(userToAdd);

            if (saveChanges)
                await _context.SaveChangesAsync();

            return true;
        }
         public async Task<User?> GetUser(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if(user != null)
                return user;
            
            return null;
        }
    }
}