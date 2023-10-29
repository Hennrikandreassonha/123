import { Component } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { WorkoutTags, Exercises } from 'src/assets/ListsForWorkout/ListsForWorkout';
import { Exercise, Workout } from 'src/app/Interfaces/Classes';
import { WorkoutService } from 'src/app/Services/workout.service';

@Component({
  selector: 'app-create-workout',
  templateUrl: './create-workout.component.html',
  styleUrls: ['./create-workout.component.css'],
  animations: [
    trigger('expandAnimation', [
      state('collapsed', style({ height: '0', opacity: 0 })),
      state('expanded', style({ height: '*', opacity: 1 })),
      transition('collapsed => expanded', animate('0.2s ease-in-out')),
      transition('expanded => collapsed', animate('0.2s ease-in-out')),
    ]),
  ],
})
export class CreateWorkoutComponent {

  public WorkoutName: string = "Minworkout";
  public Exercises: string[] = Exercises;
  public WorkoutTags = WorkoutTags;

  public ExerciseToCustomize: string = "";
  public ExercisesAdded: Exercise[] = [];

  public SetWeight: number = 0;
  public SetReps: number = 0;

  public AddedTags: string[] = [];
  public errMsg: boolean = false;

  constructor(private _workoutService: WorkoutService) {
  }

  addExercise(event: MouseEvent, item: any): void {

    if (this.ExerciseToCustomize == item) {
      this.ExerciseToCustomize = "";
    }
    else {
      this.ExerciseToCustomize = item;
    }
  }
  stopClickPropagation(event: Event): void {
    event.stopPropagation();
  }
  addCompleteExercise(item: any) {
    const exerToAdd = new Exercise(item, this.SetReps, this.SetWeight);
    this.ExercisesAdded.push(exerToAdd);
  }
  addTag(tag: any) {
    const index = this.AddedTags.indexOf(tag);

    if (index === -1) {
      this.AddedTags.push(tag);
    } else {
      this.AddedTags.splice(index, 1);
    }

    console.log(this.AddedTags);
  }
  removeExcersice(index: number) {
    this.ExercisesAdded.splice(index, 1);
  }
  addWorkout() {
    if (this.ExercisesAdded.length == 0) {
      this.errMsg = true;
      return;
    }

    const workoutToAdd: Workout = new Workout(1, this.WorkoutName, this.ExercisesAdded, this.AddedTags);

    this._workoutService.postWorkout(workoutToAdd).
      subscribe({
        next: (res) => {
          console.log(res);
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
  testGet() {
    
    this._workoutService.getWorkout().
      subscribe({
        next: (res) => {
          console.log(res);
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
