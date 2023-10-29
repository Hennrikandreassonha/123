using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Infrastructure.Repository.ExerciseRepository
{
    public interface IExerciseRepository
    {
        Task<bool> AddExercise(Exercise exercise, Guid workoutId, bool saveDb = false);
        Task<int> AddExercises(IEnumerable<ExerciseInputModel> exercises, Guid workoutId, bool saveDb = false);

    }
}