using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Domain.Users;
using WebApi.Domain.Users;

namespace WebApi.Infrastructure.UserRepository
{
    public interface IUserRepository
    {
        Task<bool> AddUser(UserInputModel user, bool saveChanges = false);
    }
}