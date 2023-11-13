using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Domain.Users
{
    public class User : DbEntity
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public User(string email, byte[]? passwordSalt, byte[]? passwordhash)
        {
            Guid guid = Guid.NewGuid();
            Id = guid;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordhash;
            LastLoginDate = DateTime.Now;
            CreatedDate = DateTime.Now;
        }
        public User(string name, string email, string phoneNumber = "")
        {
            Guid guid = Guid.NewGuid();
            Id = guid;
            Email = email;
            PhoneNumber = phoneNumber;
            LastLoginDate = DateTime.Now;
            CreatedDate = DateTime.Now;
        }
    }
}