using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Workouts;

namespace WebApi.Infrastructure.Repository.WorkoutRepository
{
    public interface IWorkoutRepository
    {
        Task<bool> AddWorkout(WorkoutInputModel workout, Guid workoutId, bool saveDb = false);
    }
}