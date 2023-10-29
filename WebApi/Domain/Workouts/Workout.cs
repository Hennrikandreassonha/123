using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Domain.Users;
using Microsoft.Extensions.Configuration.UserSecrets;
using WebApi.Domain.DbObjects;

namespace GYMAPP.Domain.Workouts
{
    public class Workout : DbEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public List<Exercise>? Excersices { get; set; }

        public Workout(Guid id, string name, DateTime createdDate, Guid userId)
        {
            this.Id = id;
            this.Name = name;
            this.CreatedDate = createdDate;
            this.ChangedDate = DateTime.Now;
            this.UserId = userId;
        }
    }
}