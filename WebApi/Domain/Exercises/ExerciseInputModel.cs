using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Exercises
{
    public class ExerciseInputModel
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }

        public ExerciseInputModel(string name, int weight, int reps)
        {
            this.Name = name;
            this.Weight = weight;
            this.Reps = reps;
        }
    }
}