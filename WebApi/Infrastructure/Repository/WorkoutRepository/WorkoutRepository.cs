using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Workouts;
using WebApi.Infrastructure.Repository.Database;

namespace WebApi.Infrastructure.Repository.WorkoutRepository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly GymAppContext _context;
        public WorkoutRepository(GymAppContext context)
        {
            _context = context;
        }
        public async Task<bool> AddWorkout(WorkoutInputModel workout, Guid workoutId, bool dbSave = false)
        {
            if (workout == null)
            {
                return false;
            }
            Guid guid = Guid.NewGuid();

            Workout workoutToAdd = new(workoutId, workout.WorkoutName, DateTime.Now, guid);

            await _context.Workouts.AddAsync(workoutToAdd);

            if (dbSave)
                await _context.SaveChangesAsync();

            return true;
        }
    }
}