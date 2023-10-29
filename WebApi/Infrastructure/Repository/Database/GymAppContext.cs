using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.Domain.Users;
using GYMAPP.Domain.Workouts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Infrastructure.Repository.Database
{
    public class GymAppContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Workout> Workouts { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;

        public GymAppContext(DbContextOptions<GymAppContext> options)
     : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}