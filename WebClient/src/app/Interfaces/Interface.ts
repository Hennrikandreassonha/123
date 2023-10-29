export interface Workout {
  userrId: number;
  workoutName: string;
  exercises: Exercise[];
  tags: string[];
}

export interface Exercise {
  name: string;
  sets: number;
  weight: number;
}
