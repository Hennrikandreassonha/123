using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infrastructure.Repository.Database;

namespace WebApi.Infrastructure.Repository.ExerciseRepository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly GymAppContext _context;
        public ExerciseRepository(GymAppContext context)
        {
            _context = context;
        }
        public async Task<bool> AddExercise(Exercise exercise, Guid workoutId
        , bool saveDb = false)
        {
            if (exercise == null)
                return false;

            _context.Exercises.Add(exercise);

            if (saveDb)
                await _context.SaveChangesAsync();

            return true;
        }
        public async Task<int> AddExercises(IEnumerable<ExerciseInputModel> exercises, Guid workoutId, bool saveDb = false)
        {
            if (exercises == null)
                return 0;

            List<Exercise> exercisesToAdd = new();

            foreach (var item in exercises)
            {
                Exercise exercise = new Exercise(item.Name, item.Weight, item.Reps, workoutId);

                exercisesToAdd.Add(exercise);
            }
            await _context.Exercises.AddRangeAsync(exercisesToAdd);

            if (saveDb)
                await _context.SaveChangesAsync();

            return exercisesToAdd.Count;
        }

    }
}