using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Domain.Users
{
    public class User : DbEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public User(string name, string email, string phoneNumber = "")
        {
            Guid guid = Guid.NewGuid();
            this.Id = guid;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.LastLoginDate = DateTime.Now;
            this.CreatedDate = DateTime.Now;
        }
    }
}