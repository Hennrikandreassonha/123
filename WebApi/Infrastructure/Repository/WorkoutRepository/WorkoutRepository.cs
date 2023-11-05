using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Workouts;
using WebApi.Infrastructure.Repository.Database;
using WebApi.Infrastructure.UserRepository;

namespace WebApi.Infrastructure.Repository.WorkoutRepository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly GymAppContext _context;
        private readonly IUserRepository _userRepo;
        
        public WorkoutRepository(GymAppContext context, IUserRepository userRepo)
        {
            _context = context;
            _userRepo = userRepo;
        }
        public async Task<bool> AddWorkout(WorkoutInputModel workout, Guid workoutId, bool dbSave = false)
        {
            if (workout == null)
            {
                return false;
            }
            Guid guid = new Guid("3CF7B5A0-A57F-46DE-887B-4E6B345DF643");

            Workout workoutToAdd = new(workoutId, workout.WorkoutName, DateTime.Now, guid);

            await _context.Workouts.AddAsync(workoutToAdd);

            if (dbSave)
                await _context.SaveChangesAsync();

            return true;
        }
    }
}