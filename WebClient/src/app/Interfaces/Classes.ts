export class Exercise {
  // Properties
  Name: string;
  Weight: number;
  Reps: number;

  // Constructor
  constructor(name: string, sets: number, weight: number) {
    this.Name = name;
    this.Reps = sets;
    this.Weight = weight;
  }
}

export class Workout {
  UserId: number;
  WorkoutName: string;
  Excercises: Exercise[];
  Tags?: string[];

  constructor(userId: number, workoutName: string, exercises: Exercise[], tags?: string[]) {
    this.UserId = userId;
    this.WorkoutName = workoutName;
    this.Excercises = exercises;
    this.Tags = tags;
  }
}
