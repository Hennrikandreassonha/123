using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GYMAPP.Domain.Exercises
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Weight { get; set; }
        public int Reps { get; set; }
        public Guid WorkoutId { get; set; }
        public Workout Workout { get; set; } = null!;

        public Exercise()
        {

        }
        public Exercise(string exerciseName, int weight, int reps, Guid workoutId)
        {
            this.Name = exerciseName;
            this.Weight = weight;
            this.Reps = reps;
            this.WorkoutId = workoutId;
        }


    }
}