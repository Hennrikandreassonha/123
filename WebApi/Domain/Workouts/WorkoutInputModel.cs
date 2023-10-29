using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.DbObjects;

namespace WebApi.Domain.Workouts
{
    public class WorkoutInputModel : InputModel
    {
        //Detta är modellen som kommer från frontenden.

        public required int UserId { get; set; }
        public required string WorkoutName { get; set; }
        public required List<ExerciseInputModel> Excercises { get; set; }
        public List<string>? Tags { get; set; }
    }
}