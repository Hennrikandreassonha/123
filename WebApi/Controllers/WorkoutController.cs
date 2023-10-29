using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GYMAPP.Domain.Workouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain.Workouts;
using WebApi.Infrastructure.Repository.ExerciseRepository;
using WebApi.Infrastructure.Repository.WorkoutRepository;

namespace GYMAPP.WebApi.Controllers
{
    [Route("[controller]")]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutRepository _workoutRepo;
        private readonly IExerciseRepository _exerciseRepo;

        public WorkoutController(IWorkoutRepository workoutRepo, IExerciseRepository exerciseRepo)
        {
            _workoutRepo = workoutRepo;
            _exerciseRepo = exerciseRepo;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkoutInputModel workout)
        {
            Guid guidForWorkout = Guid.NewGuid();
            int savedExercises;

            if (await _workoutRepo.AddWorkout(workout, guidForWorkout, true))
            {
                savedExercises = await _exerciseRepo.AddExercises(workout.Excercises, guidForWorkout, true);

                return Ok(new { Message = $"Pass med {savedExercises} övningar sparat" });
            }

            return BadRequest("Kunde ej spara pass");
        }
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("asd");
            return Ok(new { Message = "No user found" });
        }
    }
}